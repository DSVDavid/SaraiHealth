import { EventEmitter, Injectable } from '@angular/core';
import * as signalR from '@microsoft/signalr';
import { Alert } from '../models/Alert';
@Injectable({
    providedIn:'root'
})
export class SignalRService{
    // private baseLink = "https://localhost:44398/hub/patient_alert";
    private baseLink = "/hub/patient_alert";
    private hubConnection: signalR.HubConnection;
    public alertEmitter: EventEmitter<Alert> = new EventEmitter<Alert>();

    constructor(){
        this.startConnection();
        
        this.hubConnection.on("patient_alert", (patientId:number, message:string)=>{
            this.alertEmitter.emit({patientId:patientId, message:message});
        })
    }

    public startConnection = () => {
        this.hubConnection = new signalR.HubConnectionBuilder()
                            .withUrl(this.baseLink).build();
    
        this.hubConnection.start().then( () => console.log("Started connection") )
        .catch( () => console.log("Error connecting"));
    
    }

}