import { Component, OnInit } from '@angular/core';
import { CreatePersonModel } from './create-person-model';

@Component({
  selector: 'app-create-person',
  templateUrl: './create-person.component.html',
  styleUrls: ['./create-person.component.css']
})
export class CreatePersonComponent implements OnInit {
  public model: CreatePersonModel = new CreatePersonModel();
  public selectedFile: File;

  onPictureSelected(event) {
    if (event.target.files.length === 0) {
      return;
    }
  }

  onUpload() {
    // upload code goes here
  }

  ngOnInit() {
  }

  onSubmit() {
    alert("Submti9");
  }

}
