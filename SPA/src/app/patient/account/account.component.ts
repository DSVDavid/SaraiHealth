import { Component, OnInit } from '@angular/core';
import { Patient } from 'src/app/models/Patient';
import { PatientService } from 'src/app/services/patient.service';

@Component({
  selector: 'app-account',
  templateUrl: './account.component.html',
  styleUrls: ['./account.component.css']
})
export class AccountComponent implements OnInit {
  public user:Patient;
  constructor(private patientService: PatientService) { }

  ngOnInit(): void {
    this.user = new Patient();
    this.patientService.getPatient().subscribe( (p: Patient) => {
        this.user = p;
        console.log(this.user.medicalRecord)
    })
  }

}
