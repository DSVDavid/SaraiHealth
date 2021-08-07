import { Patient } from './Patient';

export class Caregiver{
    public id:number;
    public password:string;
    public name:string;
    public email:string;
    public gender:string;
    public birthDate: string;
    public address: string;
    public patients: Patient[];

}