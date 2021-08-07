import { Component, OnInit } from '@angular/core';
import { NgForm } from '@angular/forms';
import { MatDialog, MatDialogRef } from '@angular/material/dialog';
import { Medication } from 'src/app/models/Medication';
import { DoctorService } from 'src/app/services/doctor.service';

@Component({
  selector: 'app-create-medication',
  templateUrl: './create-medication.component.html',
  styleUrls: ['./create-medication.component.css']
})
export class CreateMedicationComponent implements OnInit {

  constructor(private doctorService: DoctorService,
              private dialogRef:MatDialogRef<CreateMedicationComponent>) { }

  ngOnInit(): void {
  }

  onSubmit(f:NgForm){
    console.log(f);
    let med:Medication = new Medication();
    med.name = f.value.name;
    med.sideEffects = f.value.sideEffects;
    med.dosage = f.value.dosage;

    this.doctorService.CreateMedication(med).subscribe( resp =>{
        this.dialogRef.close(true);
    });

  }

}
