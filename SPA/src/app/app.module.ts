import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms'
import { HttpClientModule, HTTP_INTERCEPTORS } from '@angular/common/http';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { LoginComponent } from './login/login.component';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { FlexLayoutModule } from '@angular/flex-layout';
import { MatCardModule } from '@angular/material/card';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatIconModule } from '@angular/material/icon';
import {MatButtonModule } from '@angular/material/button';
import { HeaderComponent } from './header/header.component';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule  } from '@angular/material/input';
import { PatientsComponent } from './doctor/patients/patients.component';
import { CaregiversComponent } from './doctor/caregivers/caregivers.component';
import { MedicationComponent } from './doctor/medication/medication.component';
import { MatTableModule } from '@angular/material/table';
import { AuthService } from './services/auth.service';
import { AccountComponent } from './patient/account/account.component';
import { JwtModule } from '@auth0/angular-jwt';
import { DoctorService } from './services/doctor.service';
import { AuthInterceptor } from './helpers/auth.interceptor';
import { CaregiverComponent } from './caregiver/caregiver.component';
import { MatPaginatorModule } from '@angular/material/paginator';
import { MatDialogModule } from '@angular/material/dialog';
import { CreatePatientComponent } from './doctor/patients/create-patient/create-patient.component';
import { EditPatientComponent } from './doctor/patients/edit-patient/edit-patient.component';
import { CreateMedicationComponent } from './doctor/medication/create-medication/create-medication.component';
import { EditMedicationComponent } from './doctor/medication/edit-medication/edit-medication.component';
import { CreateCaregiverComponent } from './doctor/caregivers/create-caregiver/create-caregiver.component';
import { EditCaregiverComponent } from './doctor/caregivers/edit-caregiver/edit-caregiver.component';
import { MatSelectModule } from '@angular/material/select';
import { PatientService } from './services/patient.service';
import { CaregiverService } from './services/caregiver.service';
import { ViewPatientComponent } from './caregiver/view-patient/view-patient.component';
import { SignalRService } from './services/signalr.service';
import {  MatSnackBarModule } from '@angular/material/snack-bar';

@NgModule({
  declarations: [
    AppComponent,
    LoginComponent,
    HeaderComponent,
    PatientsComponent,
    CaregiversComponent,
    MedicationComponent,
    AccountComponent,
    CaregiverComponent,
    CreatePatientComponent,
    EditPatientComponent,
    CreateMedicationComponent,
    EditMedicationComponent,
    CreateCaregiverComponent,
    EditCaregiverComponent,
    ViewPatientComponent,
    
  ],
  imports: [
    HttpClientModule,
    BrowserModule,
    AppRoutingModule,
    BrowserAnimationsModule,
    FlexLayoutModule,
    MatCardModule,
    MatToolbarModule,
    MatIconModule,
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule,
    FormsModule,
    MatTableModule,
    MatPaginatorModule,
    MatDialogModule,
    MatSelectModule,
    MatSnackBarModule
    // JwtModule.forRoot({})
  ],entryComponents:[
    CreatePatientComponent,
    CreateMedicationComponent,
    EditPatientComponent,
    EditMedicationComponent,
    CreateCaregiverComponent,
    EditCaregiverComponent,
    ViewPatientComponent
  ],
  providers: [AuthService, DoctorService,PatientService, CaregiverService, SignalRService,
  {
    provide: HTTP_INTERCEPTORS,
    useClass: AuthInterceptor,
    multi: true
  }],
  bootstrap: [AppComponent]
})
export class AppModule { }
