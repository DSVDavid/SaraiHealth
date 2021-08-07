import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { CaregiverComponent } from './caregiver/caregiver.component';
import { CaregiversComponent } from './doctor/caregivers/caregivers.component';
import { MedicationComponent } from './doctor/medication/medication.component';
import { PatientsComponent } from './doctor/patients/patients.component';
import { LoginComponent } from './login/login.component';
import { AccountComponent } from './patient/account/account.component';

const routes: Routes = [
  { path: 'doctor', component: PatientsComponent,
    data: {
      allowedRoles: ['doctor']
    } 
  },
  { path: 'doctor/caregivers', component: CaregiversComponent,
    data: {
      allowedRoles: ['doctor']
    } 
  },
  { path: 'doctor/medication', component: MedicationComponent,
    data: {
      allowedRoles: ['doctor']
    } 
  },
  { path: 'patient', component: AccountComponent,
    data: {
      allowedRoles: ['patient']
    } 

  },
  { path: 'caregiver', component: CaregiverComponent,
    data: {
      allowedRoles: ['caregiver']
    } 

  },
  { path: '', component: LoginComponent,
    data: {} 

  },
  
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
