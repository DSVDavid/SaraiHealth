import { Component, OnInit, ViewChild } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { MatPaginator } from '@angular/material/paginator';
import { MatSnackBar } from '@angular/material/snack-bar';
import { MatTableDataSource } from '@angular/material/table';
import { Alert } from '../models/Alert';
import { Patient } from '../models/Patient';
import { CaregiverService } from '../services/caregiver.service';
import { SignalRService } from '../services/signalr.service';
import { ViewPatientComponent } from './view-patient/view-patient.component';

@Component({
  selector: 'app-caregiver',
  templateUrl: './caregiver.component.html',
  styleUrls: ['./caregiver.component.css']
})
export class CaregiverComponent implements OnInit {
  public patients: Patient[];

  public dataSource :MatTableDataSource<Patient>
  public displayedColumns: string[] = ['id', 'name', 'email','address',
  'gender', 'birth_date','edit_button'];

  @ViewChild(MatPaginator) paginator: MatPaginator;

  constructor(private caregiverService: CaregiverService,
              private signalRService: SignalRService,
              private _snackBar: MatSnackBar,
              private dialog: MatDialog) { }

  ngOnInit(): void {

    this.signalRService.startConnection();

    this.signalRService.alertEmitter.subscribe( (alert:Alert)=>{
      console.log(alert.patientId);
      console.log(alert.message);
      console.log(this.patients);
      const patient1 =this.patients.find( p=> p.id ==alert.patientId);
      console.log(patient1);
      if(patient1!= undefined){
        this._snackBar.open(patient1.name+' : '+alert.message,'ALERT',{
          duration:2000
        });
      }  
    
    } );

    this.caregiverService.GetPatients().subscribe((patients: Patient[]) => {
        this.patients = patients;
        console.log(this.patients);
        this.dataSource = new MatTableDataSource<Patient>(this.patients);
        this.dataSource.paginator = this.paginator;
    });
  }


 

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  viewPatient(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(13);
    let p:Patient = this.patients.find(p=>p.id.toString() == id.toString());
    
    const dialogRef = this.dialog.open(ViewPatientComponent,{
      data:{
        patient:{...p}
      }
    });
    
    
    
    console.log(id);
  }




}


