import { Injectable, Inject } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Person } from '../people-search/models/person.model';
import { CreatePersonModel } from '../create-person/models/create-person.model';

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

    return this.httpClient.get<Person[]>(`${this.personApiUrl}/SearchByName?searchText=${searchText}`);
  }

  createPerson(createPersonModel: CreatePersonModel): Observable<Object> {
    return this.httpClient.post(`${this.personApiUrl}/CreatePerson`, createPersonModel);
  }
}
