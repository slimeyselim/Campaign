import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { registerLocaleData } from '@angular/common';
import { MatInputModule, MatButtonModule, MatDatepickerModule, MatSnackBarModule, MatRadioModule, MatNativeDateModule, MatTableModule, MatIconModule, MatSelectModule, MatSortModule, MatDialogModule } from '@angular/material';
import { FormsModule, ReactiveFormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import localeGb from '@angular/common/locales/fr';
registerLocaleData(localeGb, 'gb');

import { DialogAdd } from './campaign-add/campaign-add.component';
import { DialogEdit } from './campaign-edit/campaign-edit.component';
import { DialogDelete } from './campaign-delete/campaign-delete.component';
import { AppComponent } from './app.component';

import { CampaignService } from './campaign/campaign.service';
import { ClientService } from './client/client.service';

@NgModule({
  declarations: [
    AppComponent,
    DialogAdd,
    DialogEdit,
    DialogDelete
  ],
  entryComponents: [
    DialogEdit,
    DialogDelete,
    DialogAdd
  ],
  imports: [
    BrowserModule,
    HttpClientModule,
    FormsModule,
    ReactiveFormsModule,
    BrowserAnimationsModule,
    MatDialogModule,
    MatInputModule,
    MatButtonModule,
    MatSelectModule,
    MatTableModule,
    MatIconModule,
    MatDatepickerModule,
    MatSnackBarModule,
    MatRadioModule,
    MatNativeDateModule,
    MatSortModule,
  ],
  providers: [
    CampaignService,
    ClientService,
    DialogAdd,
    DialogEdit,
    DialogDelete
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
