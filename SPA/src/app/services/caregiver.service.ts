import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';


@Injectable()
export class CaregiverService{
    

    constructor(private httpClient: HttpClient){}

    // private baseLink = 'https://localhost:44398/api/caregiver/';
    private baseLink = '/api/caregiver/';

    //patient CRUD
    GetPatients(){
        return this.httpClient.get(this.baseLink);
    }



    
    

}