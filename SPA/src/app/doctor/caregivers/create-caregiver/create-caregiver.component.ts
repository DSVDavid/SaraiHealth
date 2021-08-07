import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { MatTableDataSource } from '@angular/material/table';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';
import {FormControl} from '@angular/forms';
import { Caregiver } from 'src/app/models/Caregiver';

@Component({
  selector: 'app-create-caregiver',
  templateUrl: './create-caregiver.component.html',
  styleUrls: ['./create-caregiver.component.css', './table-scrollable.scss']
})
export class CreateCaregiverComponent implements OnInit {
  private patients: Patient[];
  public availablePatients: Patient[]=[];

  public selected_patients=[];


  displayedColumns = ['id_patient','patient_name','del_patient'];
  dataSource = new MatTableDataSource<Patient>();

  constructor( public dialogRef:MatDialogRef<CreateCaregiverComponent>,
    private doctorService: DoctorService,
    @Inject(MAT_DIALOG_DATA) public passedData: any, ) { }

  ngOnInit(): void {
    this.patients = this.passedData.patients
    this.availablePatients = this.patients;
  }

  onSubmit(f:NgForm){
    console.log(f.value);
    let my_patients:Patient[] = [];
    this.selected_patients.forEach( p => {
      let my_patient = {...this.patients.find(pat => pat.id == p)}
      // console.log(my_patient);
      my_patients.push(my_patient);
      
    });
    // console.log(my_patients);
    let caregiver:Caregiver = new Caregiver();

    caregiver.patients = my_patients;
    caregiver.name = f.value.name;
    caregiver.gender = f.value.gender;
    caregiver.password = f.value.password;
    caregiver.birthDate = f.value.birthDate;
    caregiver.email = f.value.email;
    caregiver.address = f.value.address;
    console.log(caregiver);
    this.doctorService.CreateCaregiver(caregiver).subscribe(resp => {
      console.log(resp);
      this.dialogRef.close(true);
    });
  }

  

}
