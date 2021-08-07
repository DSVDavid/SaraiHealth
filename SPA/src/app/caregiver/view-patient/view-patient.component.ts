import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { EditPatientComponent } from 'src/app/doctor/patients/edit-patient/edit-patient.component';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-view-patient',
  templateUrl: './view-patient.component.html',
  styleUrls: ['./view-patient.component.css']
})
export class ViewPatientComponent implements OnInit {

  public myPatient:Patient;
  public patientDate:Date;
  constructor(private dialogRef:MatDialogRef<ViewPatientComponent>,
    @Inject(MAT_DIALOG_DATA) public passedData: any,
    ) { }

  ngOnInit(): void {
    this.myPatient = this.passedData.patient;
    this.patientDate = new Date(this.myPatient.birthDate);
    console.log(this.patientDate)
  }

  parseDate(dateString: string): string {
    if (dateString) {
        return new Date(dateString).toString();
    }
    return null;
  }

}


