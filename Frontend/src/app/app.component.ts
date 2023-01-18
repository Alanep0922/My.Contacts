import { Component, OnInit } from '@angular/core';
import { Form, FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Contact } from './models/contact';
import { ContactService } from './services/contact.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  displayedColumns: string[] = ['name', 'phone', 'email', 'actions'];
  dataSource: Contact[] = [ ];
  form: FormGroup;
  idToUpdate?: number;

  constructor(private contactService: ContactService, fb: FormBuilder){
    this.form = fb.group({
      'name': ['', Validators.required],
      'phone': ['', Validators.required],
      'email': ['', [Validators.required, Validators.email]],
    })
  }
  
  ngOnInit(): void {
    this.fetch();
  }
  
  fetch(){
    this.contactService.getContacts()
      .subscribe(response => this.dataSource = response)
  }

  deleteContact(id: number){
    this.contactService.deleteContact(id)
      .subscribe(_ => this.fetch())
  }

  cancelUpdate(){
    this.idToUpdate = undefined;
    this.form.controls['name'].setValue('');
    this.form.controls['email'].setValue('');
    this.form.controls['phone'].setValue('');
  }

  updateContact(contact: Contact){
    this.idToUpdate = contact.id;
    this.form.controls['name'].setValue(contact.name);
    this.form.controls['email'].setValue(contact.email);
    this.form.controls['phone'].setValue(contact.phone);
  }

  createOrUpdateContact(){
    if(this.idToUpdate){
      this.contactService.updateContact(this.idToUpdate, this.form.value)
        .subscribe(_ => this.fetch())      
    } else {
      this.contactService.createContact(this.form.value)
        .subscribe(_ => this.fetch())
    }
  }
}
