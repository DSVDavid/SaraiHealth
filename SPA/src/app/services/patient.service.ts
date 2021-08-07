import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../models/Patient';
import { Medication } from '../models/Medication';
import { Caregiver } from '../models/Caregiver';

@Injectable()
export class PatientService{
    constructor(private httpClient: HttpClient){}

    // private baseLink = 'https://localhost:44398/api/patient/';
    private baseLink = '/api/patient/';

    getPatient(){
      return  this.httpClient.get(this.baseLink);
    }

}