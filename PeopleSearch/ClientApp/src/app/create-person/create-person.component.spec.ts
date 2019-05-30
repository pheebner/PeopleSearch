import { async, ComponentFixture, TestBed } from '@angular/core/testing';
import { CreatePersonComponent } from './create-person.component';
import { PersonService } from '../services/person.service';
import { ImageService } from '../services/image.service';
import { FormsModule } from '@angular/forms';
import { CustomFormsModule } from 'ng2-validation';
import { ImageUploadResponse } from '../services/models/image-upload-response.model';
import { of, throwError } from 'rxjs';

describe('CreatePersonComponent', () => {
  let component: CreatePersonComponent;
  let fixture: ComponentFixture<CreatePersonComponent>;
  let imageServiceSpy: { upload: jasmine.Spy };
  let personServiceSpy: { createPerson: jasmine.Spy };

  beforeEach(async(() => {
    imageServiceSpy = jasmine.createSpyObj('ImageService', ['upload']);
    personServiceSpy = jasmine.createSpyObj('PersonService', ['createPerson']);

    TestBed.configureTestingModule({
      declarations: [ CreatePersonComponent ],
      imports: [FormsModule, CustomFormsModule],
      providers: [{ provide: ImageService, useValue: imageServiceSpy },
        { provide: PersonService, useValue: personServiceSpy }]
    })
    .compileComponents();
  }));

  beforeEach(() => {
    fixture = TestBed.createComponent(CreatePersonComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();

    component.ngOnInit();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });

  describe('onImageSelectionChanged', () => {
    it('should upload image', () => {
      const imageFiles: File[] = [new File([''], 'file')];
      const imageUploadResponse: ImageUploadResponse = { pictureUrl: 'url' };

      imageServiceSpy.upload.and.returnValue(of(imageUploadResponse));

      component.onImageSelectionChanged.next(imageFiles);

      expect(imageServiceSpy.upload).toHaveBeenCalledWith(imageFiles[0]);
      expect(component.selectedFileName).toEqual(imageFiles[0].name);
    });

    it('should assign url and file names on success', () => {
      const imageFiles: File[] = [new File([''], 'file')];
      const imageUploadResponse: ImageUploadResponse = { pictureUrl: 'url' };

      imageServiceSpy.upload.and.returnValue(of(imageUploadResponse));

      component.onImageSelectionChanged.next(imageFiles);

      expect(component.model.pictureUrl).toEqual(imageUploadResponse.pictureUrl);
      expect(component.selectedFileName).toEqual(imageFiles[0].name);
    });

    it('should show proper state on success', () => {
      const imageFiles: File[] = [new File([''], 'file')];
      const imageUploadResponse: ImageUploadResponse = { pictureUrl: 'url' };

      imageServiceSpy.upload
        .and.callFake(() => expect(component.imageUploading).toBeTruthy())
        .and.returnValue(of(imageUploadResponse));

      component.onImageSelectionChanged.next(imageFiles);

      expect(component.imageUploading).toBeFalsy();
      expect(component.imageUploadError).toBeFalsy();
    });

    it('should not assign url and file names on error', () => {
      const imageFiles: File[] = [new File([''], 'file')];

      imageServiceSpy.upload.and.returnValue(throwError(new Error()));

      component.onImageSelectionChanged.next(imageFiles);

      expect(component.model.pictureUrl).toBeFalsy();
      expect(component.selectedFileName).toBeFalsy();
    });

    it('should show proper state on error', () => {
      const imageFiles: File[] = [new File([''], 'file')];

      imageServiceSpy.upload
        .and.callFake(() => expect(component.imageUploading).toBeTruthy())
        .and.returnValue(throwError(new Error()));

      component.onImageSelectionChanged.next(imageFiles);

      expect(component.imageUploading).toBeFalsy();
      expect(component.imageUploadError).toBeTruthy();
    });
  });

  describe('onSubmit', () => {
    it('when valid should show submitted and create person', () => {
      personServiceSpy.createPerson.and.returnValue(of({}));

      component.onSubmit(true);

      expect(component.submitted).toBeTruthy();
      expect(personServiceSpy.createPerson).toHaveBeenCalledWith(component.model);
    });

    it('when invalid should show submitted but not create person', () => {
      personServiceSpy.createPerson.and.returnValue(of({}));

      component.onSubmit(false);

      expect(component.submitted).toBeTruthy();
      expect(personServiceSpy.createPerson).not.toHaveBeenCalled();
    });

    it('when valid should show proper state when person created successfully', () => {
      personServiceSpy.createPerson
        .and.callFake(() => expect(component.creating).toBeTruthy())
        .and.returnValue(of({}));

      component.onSubmit(true);

      expect(component.creating).toBeFalsy();
      expect(component.created).toBeTruthy();
      expect(component.createError).toBeFalsy();
    });

    it('when valid should show proper state when error occurred during person creation', () => {
      personServiceSpy.createPerson
        .and.callFake(() => expect(component.creating).toBeTruthy())
        .and.returnValue(throwError(new Error()));

      component.onSubmit(true);

      expect(component.creating).toBeFalsy();
      expect(component.created).toBeFalsy();
      expect(component.createError).toBeTruthy();
    });
  });

  describe('reset', () => {
    it('should reset back to initial component state', () => {
      component.model = null;
      component.selectedFileName = 'something';
      component.imageUploading = true;
      component.imageUploadError = true;
      component.submitted = true;
      component.created = true;
      component.creating = true;
      component.createError = true;

      component.reset();

      expect(component.model).not.toBeNull();
      expect(component.selectedFileName).toBeNull();
      expect(component.imageUploading).toBeFalsy();
      expect(component.imageUploadError).toBeFalsy();
      expect(component.submitted).toBeFalsy();
      expect(component.created).toBeFalsy();
      expect(component.creating).toBeFalsy();
      expect(component.createError).toBeFalsy();
    });
  });
});
