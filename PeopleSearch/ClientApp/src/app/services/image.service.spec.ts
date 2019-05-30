import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';
import { ImageService } from './image.service';
import { ImageUploadResponse } from './models/image-upload-response.model';
import { of } from 'rxjs';

describe('ImageService', () => {
  let httpClientSpy: { post: jasmine.Spy };
  let service: ImageService;
  const baseUrl = 'testhost.com';

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['post']);

    TestBed.configureTestingModule({
      providers: [ImageService, { provide: HttpClient, useValue: httpClientSpy }, { provide: 'BASE_URL', useValue: baseUrl }]
    });

    service = TestBed.get(ImageService);
  });

  it('should be created', (() => {
    expect(service).toBeTruthy();
  }));

  it('should upload form data and return expected response', (() => {
    const file = new File([''], 'filename', { type: 'image/png' });
    const imageUploadResponse: ImageUploadResponse = { pictureUrl: 'url' };

    httpClientSpy.post.and.returnValue(of(imageUploadResponse));

    service.upload(file).subscribe(
      response => expect(response).toEqual(imageUploadResponse, 'expected response'),
      fail
    );

    expect(httpClientSpy.post).toHaveBeenCalledWith(`${baseUrl}/api/Image/Upload`, jasmine.any(FormData));
  }));

});
