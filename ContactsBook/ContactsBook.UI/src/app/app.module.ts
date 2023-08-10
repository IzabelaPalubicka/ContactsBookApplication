import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { HttpClientModule } from '@angular/common/http';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ContactsComponent } from './modules/contacts/contacts.component';
import { ContactComponent } from './modules/contacts/components/contact/contact.component';
import { ContactDetailsFormComponent } from './modules/contacts/components/contact-details-form/contact-details-form.component';
import { NgbModule } from '@ng-bootstrap/ng-bootstrap';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { PaginationComponent } from './shared/components/pagination/pagination.component';

@NgModule({
  declarations: [
    AppComponent,
    ContactsComponent,
    ContactComponent,
    ContactDetailsFormComponent,
    PaginationComponent,
  ],
  imports: [
    BrowserModule,
    NgbModule,
    AppRoutingModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
  ],
  providers: [],
  bootstrap: [AppComponent],
})
export class AppModule {}
