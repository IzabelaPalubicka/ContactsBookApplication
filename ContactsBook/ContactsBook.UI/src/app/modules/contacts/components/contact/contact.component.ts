import { Component, EventEmitter, Input, Output } from '@angular/core';
import { Contact } from '../../models/contact.model';

@Component({
  selector: 'app-contact',
  templateUrl: './contact.component.html',
  styleUrls: ['./contact.component.scss'],
})
export class ContactComponent {
  @Input() contact: Contact;

  @Output() showEditModalEmitter: EventEmitter<Contact> = new EventEmitter();

  public editContact(): void {
    this.showEditModalEmitter.emit(this.contact);
  }
}
