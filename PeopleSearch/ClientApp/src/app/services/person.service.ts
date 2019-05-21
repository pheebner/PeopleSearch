import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http'
import { Observable, of } from 'rxjs'
import { Person } from '../people-search/person.model'

@Injectable({
  providedIn: 'root'
})
export class PersonService {
  private personApiUrl: string;

  constructor(private httpClient: HttpClient, @Inject('BASE_URL') baseUrl: string) {
    this.personApiUrl = `${baseUrl}/api/Person`;
  }

  searchByName(searchText: string): Observable<Person[]> {
    if (searchText.length === 0) {
      return of([]);
    }

    const queryUrl = `${this.personApiUrl}/SearchByName?searchText=${searchText}`;

    return this.httpClient.get<Person[]>(queryUrl);
  }
}
