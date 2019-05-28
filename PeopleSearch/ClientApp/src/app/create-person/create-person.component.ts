import { Component, OnInit, Inject } from '@angular/core';
import { CreatePersonModel } from './create-person-model';
import { HttpClient } from '@angular/common/http'

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

  private imageApiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.imageApiUrl = `${baseUrl}/api/Image`;
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
            const uploadData = new FormData();
            uploadData.append("file", file);
            return this.httpClient.post(`${this.imageApiUrl}/Upload`, uploadData)
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

  onSubmit() {
    this.submitted = true;
  }

}

export interface ImageUploadResponse {
  pictureUrl: string;
}
