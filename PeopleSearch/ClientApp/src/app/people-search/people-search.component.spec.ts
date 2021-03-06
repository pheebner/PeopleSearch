import { TestBed } from '@angular/core/testing';
import { throwError, of } from 'rxjs';
import { PeopleSearchComponent } from '../people-search/people-search.component';
import { PersonService } from '../services/person.service';
import { Person } from '../people-search/models/person.model';
import { setTimeout } from 'timers';

describe('PeopleSearchComponent', () => {
  let personServiceSpy: { searchByName: jasmine.Spy };
  let component: PeopleSearchComponent;

  beforeEach(() => {
    personServiceSpy = jasmine.createSpyObj('PersonService', ['searchByName']);

    TestBed.configureTestingModule({
      declarations: [PeopleSearchComponent],
      providers: [{ provide: PersonService, useValue: personServiceSpy }]
    });

    component = TestBed.createComponent(PeopleSearchComponent).componentInstance;
    component.ngOnInit();
  });

  it('should be created', (() => {
    expect(component).toBeDefined();
  }));

  it('should call person service and assign results to people', ((done: () => void) => {
    const expectedPeople: Person[] =
      [{ firstName: 'A', lastName: 'A', age: 1, interests: 'A', pictureUrl: 'A', address: null },
      { firstName: 'B', lastName: 'B', age: 2, interests: 'B', pictureUrl: 'B', address: null }];

    const searchText = 'searchText';

    personServiceSpy.searchByName.and.returnValue(of(expectedPeople));

    component.onSearchBoxKeyupEvent.next(searchText);

    // wait for debounce
    setTimeout(() => {
      expect(personServiceSpy.searchByName).toHaveBeenCalledWith(searchText);
      expect(component.people).toEqual(expectedPeople, 'expected people');
      done();
    }, 400);

  }));

  it('should set loading to true and then back to false', ((done: () => void) => {

    const searchText = 'search';

    personServiceSpy.searchByName.and.callFake(() => {
      expect(component.loading).toBeTruthy();
    }).and.returnValue(of([]));

    component.onSearchBoxKeyupEvent.next(searchText);

    // wait for debounce
    setTimeout(() => {
      expect(component.loading).toBeFalsy();
      done();
    }, 500);

  }));

  it('should only call service with last keyup text value', ((done: () => void) => {

    const firstSearchText = 'first';
    const secondSearchText = 'second';

    personServiceSpy.searchByName.and.returnValue(of([]));

    component.onSearchBoxKeyupEvent.next(firstSearchText);
    component.onSearchBoxKeyupEvent.next(secondSearchText);

    // wait for debounce
    setTimeout(() => {
      expect(personServiceSpy.searchByName).not.toHaveBeenCalledWith(firstSearchText);
      expect(personServiceSpy.searchByName).toHaveBeenCalledWith(secondSearchText);
      done();
    }, 500);

  }));

  it('should set error to true on error', ((done: () => void) => {

    const searchText = 'search';

    personServiceSpy.searchByName.and.returnValue(throwError(new Error()));

    component.onSearchBoxKeyupEvent.next(searchText);

    // wait for debounce
    setTimeout(() => {
      expect(component.error).toBeTruthy();
      done();
    }, 500);

  }));

});
