import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http';

import { PersonService } from '../services/person.service';
import { Person } from '../people-search/models/person.model';
import { of } from 'rxjs';
import { CreatePersonModel } from '../create-person/models/create-person.model';

describe('PersonService', () => {
  let httpClientSpy: { get: jasmine.Spy, post: jasmine.Spy };
  let service: PersonService;
  const baseUrl = 'testhost.com';

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get', 'post']);

    TestBed.configureTestingModule({
      providers: [PersonService, { provide: HttpClient, useValue: httpClientSpy }, { provide: 'BASE_URL', useValue: baseUrl }]
    });

    service = TestBed.get(PersonService);
  });

  it('should be created', (() => {
    expect(service).toBeTruthy();
  }));

  describe('searchByName', () => {
    it('should search with expected url and return expected results', (() => {
      const expectedPeople: Person[] =
        [{ firstName: 'A', lastName: 'A', age: 1, interests: 'A', pictureUrl: 'A', address: null },
        { firstName: 'B', lastName: 'B', age: 2, interests: 'B', pictureUrl: 'B', address: null }];

      httpClientSpy.get.and.returnValue(of(expectedPeople));

      const searchText = 'searchText';
      service.searchByName(searchText).subscribe(
        people => expect(people).toEqual(expectedPeople, 'expected people'),
        fail
      );

      expect(httpClientSpy.get).toHaveBeenCalledWith(`${baseUrl}/api/Person/SearchByName?searchText=${searchText}`);
    }));

    it('should return empty array without making network call if search text is an empty string', (() => {
      const expectedPeople: Person[] =
        [{ firstName: 'A', lastName: 'A', age: 1, interests: 'A', pictureUrl: 'A', address: null },
        { firstName: 'B', lastName: 'B', age: 2, interests: 'B', pictureUrl: 'B', address: null }];

      httpClientSpy.get.and.returnValue(of(expectedPeople));

      service.searchByName('').subscribe(
        people => expect(people).toEqual([], 'expected people'),
        fail
      );

      expect(httpClientSpy.get).not.toHaveBeenCalled();
    }));
  });

  describe('createPerson', () => {
    it('should call post with proper url and passed in parameter', () => {
      const createPersonModel = new CreatePersonModel();
      httpClientSpy.post.and.returnValue(of({}));

      service.createPerson(createPersonModel);

      expect(httpClientSpy.post).toHaveBeenCalledWith(`${baseUrl}/api/Person/CreatePerson`, createPersonModel);
    });
  });

});
