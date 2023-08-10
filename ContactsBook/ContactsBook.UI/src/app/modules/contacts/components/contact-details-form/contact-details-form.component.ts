import {
  Component,
  EventEmitter,
  Output,
  TemplateRef,
  ViewChild,
} from '@angular/core';
import { NgbModal } from '@ng-bootstrap/ng-bootstrap';
import { Contact } from '../../models/contact.model';
import { ContactsService } from '../../services/contacts.service';
import { FormControl, FormGroup, Validators } from '@angular/forms';

@Component({
  selector: 'app-contact-details-form',
  templateUrl: './contact-details-form.component.html',
  styleUrls: ['./contact-details-form.component.scss'],
})
export class ContactDetailsFormComponent {
  @ViewChild('contactModal') contactModal: TemplateRef<any>;

  @Output() onChangedContact = new EventEmitter();

  isEditingMode = true;
  contact: Contact = new Contact();

  contactForm = new FormGroup({
    firstName: new FormControl('', [
      Validators.required,
      Validators.maxLength(50),
    ]),
    lastName: new FormControl('', [
      Validators.required,
      Validators.minLength(1),
      Validators.maxLength(50),
    ]),
    email: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
      Validators.pattern('^[a-z0-9._%+-]+@[a-z0-9.-]+\\.[a-z]{2,4}$'),
    ]),
    phoneNumber: new FormControl('', [
      Validators.required,
      Validators.maxLength(20),
      Validators.pattern('[- +()0-9]+'),
    ]),
    address: new FormControl('', [
      Validators.required,
      Validators.maxLength(100),
    ]),
    city: new FormControl('', [Validators.required, Validators.maxLength(50)]),
    zip: new FormControl('', [Validators.required, Validators.maxLength(10)]),
  });

  constructor(
    private modalService: NgbModal,
    private contactsService: ContactsService
  ) {}

  public open(contact: Contact, isEditingMode: boolean): void {
    this.contactForm.reset();
    this.isEditingMode = isEditingMode;
    this.contact = Object.assign({}, contact);

    this.setFormValues(contact);

    this.modalService
      .open(this.contactModal, { ariaLabelledBy: 'modal-basic-title' })
      .result.then(
        (result) => {
          this.getFormValues();
          if (isEditingMode) {
            this.contactsService.updateContact(this.contact).subscribe(() => {
              this.onChangedContact.emit();
            });
          } else {
            this.contactsService.createContact(this.contact).subscribe(() => {
              this.onChangedContact.emit();
            });
          }
        },
        (reason) => {}
      );
  }

  public getTitle(): string {
    if (this.isEditingMode) {
      return 'Edit Contact';
    }
    return 'Create Contact';
  }

  public showInvalidInputMessage(controlName: string): boolean {
    return (
      this.contactForm.controls[controlName].invalid &&
      this.contactForm.controls[controlName].touched
    );
  }

  public isRequiredValidationFailure(controlName: string): boolean {
    return (
      this.showInvalidInputMessage(controlName) &&
      this.contactForm.controls[controlName].errors.required
    );
  }

  public isMaxLengthValidationFailure(controlName: string): boolean {
    return (
      this.showInvalidInputMessage(controlName) &&
      this.contactForm.controls[controlName].errors.maxlength
    );
  }

  public isPatternValidationFailure(controlName: string): boolean {
    return (
      this.showInvalidInputMessage(controlName) &&
      this.contactForm.controls[controlName].errors.pattern
    );
  }

  public requiredInfo() {
    return 'Field is required';
  }

  public maxLengthInfo(controlName: string) {
    const maxLength =
      this.contactForm.controls[controlName].errors.maxlength.requiredLength;
    return 'Max. length ' + maxLength;
  }

  private setFormValues(contact: Contact): void {
    this.contactForm.controls['firstName'].setValue(contact.firstName);
    this.contactForm.controls['lastName'].setValue(contact.lastName);
    this.contactForm.controls['email'].setValue(contact.email);
    this.contactForm.controls['phoneNumber'].setValue(contact.phoneNumber);
    this.contactForm.controls['address'].setValue(contact.address);
    this.contactForm.controls['city'].setValue(contact.city);
    this.contactForm.controls['zip'].setValue(contact.zip);
  }

  private getFormValues() {
    this.contact.firstName = this.contactForm.get('firstName').value;
    this.contact.lastName = this.contactForm.get('lastName').value;
    this.contact.email = this.contactForm.get('email').value;
    this.contact.phoneNumber = this.contactForm.get('phoneNumber').value;
    this.contact.address = this.contactForm.get('address').value;
    this.contact.city = this.contactForm.get('city').value;
    this.contact.zip = this.contactForm.get('zip').value;
  }
}
