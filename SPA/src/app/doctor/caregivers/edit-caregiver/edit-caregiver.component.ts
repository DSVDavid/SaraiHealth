import { Component, Inject, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Caregiver } from 'src/app/models/Caregiver';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-edit-caregiver',
  templateUrl: './edit-caregiver.component.html',
  styleUrls: ['./edit-caregiver.component.css']
})
export class EditCaregiverComponent implements OnInit {

  public caregiver: Caregiver;
  public patients: Patient[];
  public selected_patients = [];
  public availablePatients:Patient[];

  constructor(public dialogRef:MatDialogRef<EditCaregiverComponent>,
    private doctorService: DoctorService,
    @Inject(MAT_DIALOG_DATA) public passedData: any,) {
       
     }

  ngOnInit(): void {
    this.caregiver = this.passedData.caregiver;
    this.caregiver.id = this.passedData.caregiver.id;
    
    this.patients = this.passedData.patients;
    this.availablePatients = this.patients
    this.selected_patients = this.caregiver.patients.map(c => c.id);
  }

  parseDate(dateString: string): string {
    if (dateString) {
        return new Date(dateString).toString();
    }
    return null;
  }

  onSubmit(f: NgForm){
    console.log(f.value);

    let my_patients:Patient[] = [];
    this.selected_patients.forEach( p => {
      let my_patient = {...this.patients.find(pat => pat.id == p)}
      // console.log(my_patient);
      my_patients.push(my_patient);
      
    });
    
    
    this.caregiver.patients = my_patients;
   

    this.doctorService.updateCaregiver(this.caregiver).subscribe( resp => {
      this.dialogRef.close(true);
    })

  }

}
