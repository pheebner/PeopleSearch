import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject, Observable, of } from 'rxjs';
import { debounceTime, distinctUntilChanged, tap, map, switchAll } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './people-search.component.html'
})
export class PeopleSearchComponent {
  public people: Person[];
  public loading: boolean = false;
  public onSearchBoxKeyupEvent: Subject<string> = new Subject<string>();

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit(): void {
    this.onSearchBoxKeyupEvent
      .pipe(
        debounceTime(300),
        distinctUntilChanged(),
        tap(() => this.loading = true),
        map((query: string) => this.search(query)),
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

  search(query: string): Observable<Person[]> {
    if (query.length === 0) {
      return of([]);
    }

    return this.httpClient.get<Person[]>(this.baseUrl + 'api/Person/SearchByName?searchText=' + query);
  }
}

interface Person {
  firstName: string;
  lastName: string;
  age: number;
  interests: string;
  pictureUrl: string;
}
