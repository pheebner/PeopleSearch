import { TestBed, inject } from '@angular/core/testing';

import { PersonService } from '../services/person.service';

describe('PersonService', () => {
  beforeEach(() => {
    TestBed.configureTestingModule({
      providers: [PersonService]
    });
  });

  it('should be created', inject([PersonService], (service: PersonService) => {
    expect(service).toBeTruthy();
  }));
});
