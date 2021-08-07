import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-edit-patient',
  templateUrl: './edit-patient.component.html',
  styleUrls: ['./edit-patient.component.css']
})
export class EditPatientComponent implements OnInit {
  public myPatient:Patient;
  public patientDate:Date;
  constructor(private dialogRef:MatDialogRef<EditPatientComponent>,
    @Inject(MAT_DIALOG_DATA) public passedData: any,
    private doctorService:DoctorService) { }

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

  onSubmit(f: NgForm){
   
   // this.myPatient.birthDate = f.value.birthDate;
    this.doctorService.UpdatePatient(this.myPatient).subscribe( resp => {
      this.dialogRef.close(true);
    })
  }

}
