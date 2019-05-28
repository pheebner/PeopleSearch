import { Component, OnInit, Inject } from '@angular/core';
import { CreatePersonModel } from './create-person-model';
import { HttpClient } from '@angular/common/http'

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {
  public model: CreatePersonModel = new CreatePersonModel();
  public selectedFile: File;
  public uploadingPicture: boolean;

  private imageApiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.imageApiUrl = `${baseUrl}/api/Image`;
  }

  onPictureSelected(event) {
    if (event.target.files.length === 0) {
      return;
    }

    this.uploadingPicture = true;
    this.selectedFile = event.target.files[0];
    let uploadData = new FormData();
    uploadData.append("file", this.selectedFile);
    this.httpClient.post(`${this.imageApiUrl}/Upload`, uploadData)
      .subscribe(results => {
        this.uploadingPicture = false;
      },
        err => this.uploadingPicture = false,
        () => this.uploadingPicture = false);
  }

  ngOnInit() {
  }

  onSubmit() {
    alert("Submti9");
  }

}
