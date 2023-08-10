import { Component, OnDestroy, OnInit, ViewChild } from '@angular/core';
import { ContactsService, SearchParams } from './services/contacts.service';
import { Contact } from './models/contact.model';
import { ContactDetailsFormComponent } from './components/contact-details-form/contact-details-form.component';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-contacts',
  templateUrl: './contacts.component.html',
  styleUrls: ['./contacts.component.scss'],
})
export class ContactsComponent implements OnInit, OnDestroy {
  @ViewChild('contactModal') contactModal: ContactDetailsFormComponent;

  contacts: Contact[] = [];
  totalCount: number = 0;
  typedSearchValue: string = '';
  searchValue: string = '';
  currentPageIndex = 1;
  editedContact: Contact = new Contact();
  pageSize = 5;

  getContactsSubscription: Subscription;

  constructor(private contactsService: ContactsService) {}

  ngOnInit(): void {
    this.getContacts();
  }

  ngOnDestroy(): void {
    this.getContactsSubscription.unsubscribe();
  }

  public createContact(): void {
    this.contactModal.open(new Contact(), false);
  }

  public editContact(editedContact: Contact): void {
    this.contactModal.open(editedContact, true);
  }

  public searchByValue() {
    this.searchValue = this.typedSearchValue;

    this.getContacts();
  }

  public getContacts(): void {
    const params: SearchParams = {
      pageSize: this.pageSize,
      pageIndex: this.currentPageIndex,
      search: this.searchValue,
    };

    if (!this.getContactsSubscription?.closed) {
      this.getContactsSubscription?.unsubscribe();
    }

    this.getContactsSubscription = this.contactsService
      .getContacts(params)
      .subscribe((result: any) => {
        this.contacts = result.items;
        this.totalCount = result.totalCount;
      });
  }

  public onSelectedPageIndex(newPageIndex: number): void {
    this.currentPageIndex = newPageIndex;

    this.getContacts();
  }
}
