import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppComponent } from './app.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatTableModule } from "@angular/material/table";
import { ManagerTableComponent } from './components/manager-table/manager-table.component';
import {ManagerService} from "./services/manager.service";
import {ManagerHttpService} from "./services/manager-http.service";
import {HttpClientModule} from "@angular/common/http";
import { ManagerFormComponent } from './components/manager-form/manager-form.component';
import {MatSelectModule} from "@angular/material/select";
import {FormsModule, ReactiveFormsModule} from "@angular/forms";
import {MatInputModule} from "@angular/material/input";
import {MatFormFieldModule} from "@angular/material/form-field";

@NgModule({
  declarations: [
    AppComponent,
    ManagerTableComponent,
    ManagerFormComponent
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    BrowserAnimationsModule,
    MatTableModule,
    MatSelectModule,
    FormsModule,
    ReactiveFormsModule,
    MatInputModule,
    MatFormFieldModule
  ],
  providers: [
    ManagerHttpService,
    ManagerService,
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
