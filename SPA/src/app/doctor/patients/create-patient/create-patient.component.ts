import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-create-patient',
  templateUrl: './create-patient.component.html',
  styleUrls: ['./create-patient.component.css']
})
export class CreatePatientComponent implements OnInit {

  constructor( private dialogRef:MatDialogRef<CreatePatientComponent>,
               private doctorService: DoctorService) { }

  ngOnInit(): void {
    
  }

  onSubmit(f:NgForm){
    let p:Patient = new Patient();
    p.address = f.value.address;
    p.birthDate = f.value.birthDate;
    p.name = f.value.name;
    p.email = f.value.email;
    p.gender = f.value.gender;
    p.medicalRecord = f.value.medicalRecord;
    p.password = f.value.password;
    this.doctorService.CreatePatient(p).subscribe(
      (resp) => {
        this.dialogRef.close(true);
      },(error) =>{
        console.log(error);
      }
    );
    
  }

}
