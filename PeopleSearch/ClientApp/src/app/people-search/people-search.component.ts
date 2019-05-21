import { Component } from '@angular/core';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap, map, switchAll } from 'rxjs/operators';
import { Person } from '../people-search/person.model';
import { PersonService } from '../services/person.service';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './people-search.component.html'
})
export class PeopleSearchComponent {
  public people: Person[];
  public loading: boolean = false;
  public onSearchBoxKeyupEvent: Subject<string> = new Subject<string>();

  constructor(private personService: PersonService) {
  }

  ngOnInit(): void {
    this.onSearchBoxKeyupEvent
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        tap(() => this.loading = true),
        map((searchText: string) => this.personService.searchByName(searchText)),
        switchAll<Person[]>()
      )
      .subscribe(
        results => {
          this.people = results;
          this.loading = false;
        },
        err => {
          console.log(err);
          this.loading = false;
        },
        () => this.loading = false
      );
  }
}
