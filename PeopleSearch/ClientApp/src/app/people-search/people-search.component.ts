import { Component, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Component({
  selector: 'app-fetch-data',
  templateUrl: './people-search.component.html'
})
export class PeopleSearchComponent {
  public people: Person[];

  constructor(http: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    http.get<Person[]>(baseUrl + 'api/Person/SearchByName?searchText=bann').subscribe(result => {
      this.people = result;
    }, error => console.error(error));
  }
}

interface Person {
  firstName: string;
  lastName: string;
  age: number;
  interests: string;
}
