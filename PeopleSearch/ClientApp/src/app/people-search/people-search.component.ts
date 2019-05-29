import { Component } from '@angular/core';
import { Subject, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap, map, switchAll, catchError } from 'rxjs/operators';
import { Person } from '../people-search/models/person.model';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './people-search.component.html'
})
export class PeopleSearchComponent {
  public people: Person[] = [];
  public loading: boolean = false;
  public error: boolean = false;
  public onSearchBoxKeyupEvent: Subject<string> = new Subject<string>();

  constructor(private personService: PersonService) {
  }

  ngOnInit(): void {
    this.onSearchBoxKeyupEvent
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        tap(() => {
          this.loading = true;
          this.error = false;
        }),
        map((searchText: string) => 
          this.personService.searchByName(searchText)
            .pipe(catchError(err => {
              console.log(err);
              this.error = true;
              return of(<Person[]>[]);
            }))
        ),
        switchAll<Person[]>()
      )
      .subscribe(
        results => {
          this.people = results;
          this.loading = false;
        }
      );
  }
}
