import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact.model';

export class SearchParams {
  pageSize: number;
  pageIndex: number;
  search: string;
}

@Injectable({
  providedIn: 'root',
})
export class ContactsService {
  private url = 'https://localhost:7243/contacts';

  private headers = new HttpHeaders({
    'Content-Type': 'application/json',
  });

  constructor(private http: HttpClient) {}

  public getContacts(params: SearchParams): Observable<any> {
    return this.http.post(this.url + '/list', params, {
      headers: this.headers,
    });
  }

  public createContact(contact: Contact): Observable<any> {
    return this.http.post(this.url, contact, {
      headers: this.headers,
    });
  }

  public updateContact(contact: Contact): Observable<any> {
    return this.http.put(this.url, contact, {
      headers: this.headers,
    });
  }
}
