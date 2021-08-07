import { Component, OnInit, ViewChild } from '@angular/core';
import { Patient } from 'src/app/models/Patient';
import { DoctorService } from 'src/app/services/doctor.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { CreatePatientComponent } from './create-patient/create-patient.component';
import { EditPatientComponent } from './edit-patient/edit-patient.component';

@Component({
  selector: 'app-patients',
  templateUrl: './patients.component.html',
  styleUrls: ['./patients.component.css']
})
export class PatientsComponent implements OnInit {
  
  private patients:Patient[];
  public dataSource :MatTableDataSource<Patient>
  public displayedColumns: string[] = ['id', 'name', 'email','address',
  'gender', 'birth_date','edit_button','delete_button'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  constructor(private doctorService: DoctorService, private dialog: MatDialog) { }
  
 


  ngOnInit(): void {
    this.doctorService.GetPatients().subscribe( (my_patients:Patient[]) => {
        this.patients= my_patients;
        this.dataSource = new MatTableDataSource<Patient>(this.patients);
        // console.log(this.patients);

        this.dataSource.paginator = this.paginator;
      });

      
  }

  refreshData(){
    this.doctorService.GetPatients().subscribe( (my_patients:Patient[]) => {
      this.patients= my_patients;
      this.dataSource = new MatTableDataSource<Patient>(this.patients);
      // console.log(this.patients);

      setTimeout(() => this.dataSource.paginator = this.paginator);
    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  editPatient(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(13);
     let p:Patient = this.patients.find(p=>p.id.toString() == id.toString());
    const dialogRef = this.dialog.open(EditPatientComponent,{
      data:{
        patient:{...p}
      }
    });
    dialogRef.afterClosed().subscribe( res => {
      if(res){
        this.refreshData();
      }
    })
    console.log(id);
  }

  removePatient(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(8);

    console.log(id);

    this.doctorService.RemovePatient(id as unknown as number).subscribe( res => {
      this.refreshData();
    })
  }

  createPatient(){
    const dialogRef = this.dialog.open(CreatePatientComponent);

    dialogRef.afterClosed().subscribe( (res)=>{
      if(res){
        this.refreshData();
      }
    })
  }


}


