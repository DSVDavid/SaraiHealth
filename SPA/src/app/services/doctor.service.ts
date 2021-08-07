import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Patient } from '../models/Patient';
import { Medication } from '../models/Medication';
import { Caregiver } from '../models/Caregiver';

@Injectable()
export class DoctorService{

    constructor(private httpClient: HttpClient){}

    // private baseLink = 'https://localhost:44398/api/doctor/';
    private baseLink = '/api/doctor/';


    //patient CRUD
    GetPatients(){
        return this.httpClient.get(this.baseLink+'patients');
    }


    CreatePatient(patient: Patient){
        return this.httpClient.post(this.baseLink+'patient', {...patient});
    }

    UpdatePatient(patient: Patient){
        return this.httpClient.put(this.baseLink+'patient',{...patient});

    }

    RemovePatient(id: number){
        return this.httpClient.delete(this.baseLink+`patient/${id}`);
    }

    //Medication CRUD

    GetMedications(){
        return this.httpClient.get(this.baseLink+'medications');

    }

    CreateMedication(med: Medication){
        return this.httpClient.post(this.baseLink+`medication`,{...med});
    }

    DeleteMedication(medId: number){
        return this.httpClient.delete(this.baseLink+`medication/${medId}`);
    }

    UpdateMedication(med: Medication){
        return this.httpClient.put(this.baseLink+`medication`,{...med});
    }

    //caregivers CRUD

    GetCaregivers(){
        return this.httpClient.get(this.baseLink+'caregivers');

    }

    CreateCaregiver(car: Caregiver){
        return this.httpClient.post(this.baseLink+'caregiver',car);

    }

    deleteCaregiver(id: number){
        return this.httpClient.delete(this.baseLink+`caregiver/${id}`);
    }

    updateCaregiver(car: Caregiver){
        return this.httpClient.put(this.baseLink+`caregiver`,{...car});
    }

    
    

}