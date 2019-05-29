import { Component, OnInit, Inject } from '@angular/core';
import { CreatePersonModel } from './models/create-person.model';
import { PersonService } from '../services/person.service';
import { ImageService } from '../services/image.service';
import { ImageUploadResponse } from './models/image-upload-response.model';

import { Subject, of } from 'rxjs';
import { tap, map, switchAll, catchError, filter } from 'rxjs/operators';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {
  public model: CreatePersonModel = new CreatePersonModel();
  public selectedFileName: string;
  public onImageSelectionChanged = new Subject<File[]>();
  public imageUploading: boolean;
  public imageUploadError: boolean = false;
  public submitted: boolean = false;
  public created: boolean = false;
  public creating: boolean = false;
  public createError: boolean = false;

  constructor(private imageService: ImageService, private personService: PersonService) {
  }

  ngOnInit() {
    this.onImageSelectionChanged
      .pipe(
        filter((files: File[]) => files.length === 1),
        map((files: File[]) => files[0]),
        tap((file: File) => {
          this.imageUploading = true;
          this.imageUploadError = false;
          this.selectedFileName = file.name;
        }),
        map((file: File) => {
            return this.imageService.upload(file)
              .pipe(catchError(err => {
                console.log(err);
                this.imageUploadError = true;
                this.selectedFileName = null;
                return of(null as ImageUploadResponse);
              }));
          }
        ),
        switchAll<ImageUploadResponse>()
      )
      .subscribe(
        results => {
          if (results != null) {
            this.model.pictureUrl = results.pictureUrl;
          }

          this.imageUploading = false;
        }
      );
  }

  onSubmit(valid: boolean) {
    this.submitted = true;

    if (!valid) {
      return;
    }

    this.creating = true;
    this.createError = false;

    this.personService.createPerson(this.model)
      .subscribe(() => {
          this.created = true;
          this.creating = false;
        },
        err => {
          console.log(err);
          this.creating = false;
          this.createError = true;
        });
  }

  reset() {
    this.model = new CreatePersonModel();
    this.selectedFileName = null;
    this.imageUploading = false;
    this.imageUploadError = false;
    this.submitted = false;
    this.created = false;
    this.creating = false;
    this.createError = false;
  }

}
