import { Inject } from '@angular/core';
import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialogRef, MAT_DIALOG_DATA } from '@angular/material/dialog';
import { Medication } from 'src/app/models/Medication';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-edit-medication',
  templateUrl: './edit-medication.component.html',
  styleUrls: ['./edit-medication.component.css']
})
export class EditMedicationComponent implements OnInit {
  public myMed:Medication;

  constructor(private dialogRef:MatDialogRef<EditMedicationComponent>,
    @Inject(MAT_DIALOG_DATA) public passedData: any,
    private doctorService:DoctorService) { }

  ngOnInit(): void {
    this.myMed = new Medication();
    this.myMed.id = this.passedData.medication.id;
    this.myMed.name = this.passedData.medication.name;
    this.myMed.sideEffects = this.passedData.medication.sideEffects;
    this.myMed.dosage = this.passedData.medication.dosage;
  }

  onSubmit(f:NgForm){
    this.doctorService.UpdateMedication(this.myMed).subscribe(res =>{
      this.dialogRef.close(true);
    });
    
  }

}
