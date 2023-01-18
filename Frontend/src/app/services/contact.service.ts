import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Contact } from '../models/contact';

@Injectable({
  providedIn: 'root'
})
export class ContactService {

  constructor(private http: HttpClient) { }

  getContacts(): Observable<Contact[]> {
    return this.http.get<Contact[]>('/api/contacts');
  }

  updateContact(id: number, contact: Contact): Observable<void>{
    return this.http.put<void>(`/api/contacts/${id}`, contact);
  }

  deleteContact(id: number): Observable<void>{
    return this.http.delete<void>(`/api/contacts/${id}`);
  }

  createContact(contact: Contact): Observable<void> {
    return this.http.post<void>(`/api/contacts/`, contact);
  }
}
