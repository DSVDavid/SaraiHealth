import { Component, OnInit, ViewChild } from '@angular/core';
import { DoctorService } from 'src/app/services/doctor.service';
import {MatPaginator} from '@angular/material/paginator';
import {MatTableDataSource} from '@angular/material/table';
import { Medication } from 'src/app/models/Medication';
import { MatDialog } from '@angular/material/dialog';
import { CreateMedicationComponent } from './create-medication/create-medication.component';
import { EditMedicationComponent } from './edit-medication/edit-medication.component';
@Component({
  selector: 'app-medication',
  templateUrl: './medication.component.html',
  styleUrls: ['./medication.component.css']
})
export class MedicationComponent implements OnInit {

  private medications:Medication[];
  public dataSource: MatTableDataSource<Medication>;
  public displayedColumns: string[] = ['id', 'name','dosage','side_effects',
   'edit_button', 'delete_button'];
  
  
  constructor(private doctorService: DoctorService, private dialog:MatDialog) { }

  @ViewChild(MatPaginator) paginator: MatPaginator;

  ngOnInit(): void {
    this.doctorService.GetMedications().subscribe( (my_meds:Medication[]) => {
      this.medications = my_meds;
      this.dataSource = new MatTableDataSource<Medication>(this.medications);
   
      this.dataSource.paginator = this.paginator;
    })
  }

  refreshData(){
    this.doctorService.GetMedications().subscribe( (my_meds:Medication[]) => {
      this.medications = my_meds;
      this.dataSource = new MatTableDataSource<Medication>(this.medications);
   
      this.dataSource.paginator = this.paginator;
    })
  }

  applyFilter(event: Event) {
    const filterValue = (event.target as HTMLInputElement).value;
    this.dataSource.filter = filterValue.trim().toLowerCase();

    if (this.dataSource.paginator) {
      this.dataSource.paginator.firstPage();
    }
  }

  createMedication(){
    const dialogRef = this.dialog.open(CreateMedicationComponent);

    dialogRef.afterClosed().subscribe( (res)=>{
      if(res){
        this.refreshData();
      }
    })
  }

  removeMedication(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(11);

    console.log(id);

   this.doctorService.DeleteMedication(id as unknown as number).subscribe( resp => {
     this.refreshData();
   })

  }

  editMedication(event){
    let target = event.target || event.srcElement || event.currentTarget;
    const idAttr:string = target.attributes.id.value;

    const id = idAttr.substr(16);
    const med:Medication =this.medications.find(m => m.id.toString() == id.toString());
    console.log(med);
    const dialogRef = this.dialog.open(EditMedicationComponent,{
      data:{
        medication:med
      }
    });

    dialogRef.afterClosed().subscribe(res => {
      this.refreshData();
    })
  }

}
