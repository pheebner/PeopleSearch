import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { ImageUploadResponse } from './models/image-upload-response.model';

@Injectable({
  providedIn: 'root'
})
export class ImageService {
  private imageApiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.imageApiUrl = `${baseUrl}/api/Image`;
  }

  upload(file: File): Observable<ImageUploadResponse> {
    const uploadData = new FormData();
    uploadData.append('file', file);
    return this.httpClient.post<ImageUploadResponse>(`${this.imageApiUrl}/Upload`, uploadData);
  }
}
