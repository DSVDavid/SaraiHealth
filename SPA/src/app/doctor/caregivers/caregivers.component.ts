import { Component, OnInit, ViewChild } from '@angular/core';
import {DoctorService } from 'src/app/services/doctor.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { MatDialog } from '@angular/material/dialog';
import { Caregiver } from 'src/app/models/Caregiver';
import { Patient } from 'src/app/models/Patient';
import { CreateCaregiverComponent } from './create-caregiver/create-caregiver.component';
import { NgForm } from '@angular/forms';
import { EditCaregiverComponent } from './edit-caregiver/edit-caregiver.component';

@Component({
  selector: 'app-caregivers',
  templateUrl: './caregivers.component.html',
  styleUrls: ['./caregivers.component.css']
})
export class CaregiversComponent implements OnInit {
  
  private patients:Patient[];
  private caregivers:Caregiver[];
  public dataSource :MatTableDataSource<Caregiver>
  public displayedColumns: string[] = ['id', 'name', 'email','address',
  'gender', 'birth_date','edit_button','delete_button'];

  @ViewChild(MatPaginator) paginator: MatPaginator;
  
  constructor(private doctorService: DoctorService, private dialog: MatDialog) { }
  
 


  ngOnInit(): void {
    this.doctorService.GetCaregivers().subscribe( (my_caregivers:Caregiver[]) => {
        this.caregivers= my_caregivers;
        this.dataSource = new MatTableDataSource<Caregiver>(this.caregivers);
        // console.log(this.patients);

        this.dataSource.paginator = this.paginator;
      });

    this.doctorService.GetPatients().subscribe( (my_patients:Patient[]) => {
      this.patients = my_patients;
    })

      
  }

  refreshData(){
    this.doctorService.GetCaregivers().subscribe( (my_caregivers:Caregiver[]) => {
      this.caregivers= my_caregivers;
      this.dataSource = new MatTableDataSource<Caregiver>(this.caregivers);
      // console.log(this.patients);

      setTimeout(() => this.dataSource.paginator = this.paginator );
    });
  }


  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  editCaregiver(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(15);

    let caregiver = this.caregivers.find( c => c.id.toString() == id.toString());
    const dialogRef = this.dialog.open(EditCaregiverComponent, {
      data:{
        patients:this.patients,
        caregiver: caregiver
      }
    });

    dialogRef.afterClosed().subscribe( resp => {
      if(resp){
        this.refreshData();
      }
    })
  }

  removeCaregiver(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(10);

    this.doctorService.deleteCaregiver(id as unknown as number).subscribe( res => {
      this.refreshData();
    })
    
  }

  createCaregiver(){
    const dialogRef = this.dialog.open(CreateCaregiverComponent, {
      data:{
        patients:this.patients
      }
    });

    dialogRef.afterClosed().subscribe( (res)=>{
      if(res){
        this.refreshData();
      }
    })
  }

  


}


