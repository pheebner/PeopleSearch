import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Subject } from 'rxjs';
import { debounceTime, distinctUntilChanged } from 'rxjs/operators';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './people-search.component.html'
})
export class PeopleSearchComponent {
  public people: Person[];
  public loading: boolean = false;
  public searchboxTextChangeSubject: Subject<string> = new Subject<string>();

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') private baseUrl: string) {
  }

  ngOnInit(): void {
    this.searchboxTextChangeSubject
      .pipe(debounceTime(300), distinctUntilChanged())
      .subscribe(result => this.onSearchboxTextChanged(result));
  }

  onSearchboxTextChanged(searchText) {
    if (searchText.length === 0) {
      this.people = [];
      return;
    }

    this.loading = true;

    this.httpClient.get<Person[]>(this.baseUrl + 'api/Person/SearchByName?searchText=' + searchText)
      .subscribe(
        result => this.people = result,
        null,
        () => this.loading = false
      );
  }

  onSearchBoxKeyupEvent($event) {
    this.searchboxTextChangeSubject.next($event.target.value);
  }
}

interface Person {
  firstName: string;
  lastName: string;
  age: number;
  interests: string;
}
