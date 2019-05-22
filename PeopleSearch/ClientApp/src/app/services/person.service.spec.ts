import { TestBed } from '@angular/core/testing';
import { HttpClient } from '@angular/common/http'

import { PersonService } from '../services/person.service';
import { Person } from '../people-search/person.model';
import { asyncData } from '../testing/async-observable-helper';

describe('PersonService', () => {
  let httpClientSpy: { get: jasmine.Spy };
  let fixture: PersonService;
  const baseUrl: string = 'testhost.com';

  beforeEach(() => {
    httpClientSpy = jasmine.createSpyObj('HttpClient', ['get']);

    TestBed.configureTestingModule({
      providers: [PersonService, { provide: HttpClient, useValue: httpClientSpy }, { provide: 'BASE_URL', useValue: baseUrl }]
    });

    fixture = TestBed.get(PersonService);
  });

  it('should be created', (() => {
    expect(fixture).toBeTruthy();
  }));

  it('should search with expected url and return expected results', (() => {
    const expectedPeople: Person[] =
      [{ firstName: 'A', lastName: 'A', age: 1, interests: 'A', pictureUrl: 'A', address: null },
      { firstName: 'B', lastName: 'B', age: 2, interests: 'B', pictureUrl: 'B', address: null }];

    httpClientSpy.get.and.returnValue(asyncData(expectedPeople));

    let searchText: string = 'searchText';
    fixture.searchByName(searchText).subscribe(
      people => expect(people).toEqual(expectedPeople, 'expected people'),
      fail
    );

    expect(httpClientSpy.get).toHaveBeenCalledWith(`${baseUrl}/api/Person/SearchByName?searchText=${searchText}`);
  }))

  it('should return empty array without making network call if search text is an empty string', (() => {
    const expectedPeople: Person[] =
      [{ firstName: 'A', lastName: 'A', age: 1, interests: 'A', pictureUrl: 'A', address: null },
      { firstName: 'B', lastName: 'B', age: 2, interests: 'B', pictureUrl: 'B', address: null }];

    httpClientSpy.get.and.returnValue(asyncData(expectedPeople));

    fixture.searchByName('').subscribe(
      people => expect(people).toEqual([], 'expected people'),
      fail
    );

    expect(httpClientSpy.get).not.toHaveBeenCalled();
  }))

});
