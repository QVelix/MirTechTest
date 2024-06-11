import {Component, Inject} from '@angular/core';
import {HttpClient} from "@angular/common/http";
import {MatDialog} from "@angular/material/dialog";
import {StaffModalComponent} from "../staff-modal/staff-modal.component";
import {IStaff} from "../Interfaces/IStaff";

@Component({
  selector: 'app-staff',
  templateUrl: './staff.component.html',
  styleUrls: ['./staff.component.css']
})
export class StaffComponent {
  public staffs: IStaff[] = [];

  constructor(public http: HttpClient, @Inject('BASE_URL') public baseUrl: string, public dialog: MatDialog) {
    http.get<IStaff[]>(baseUrl + 'staff').subscribe(result => {
      this.staffs = result;
    }, error => console.error(error));
  }

  onClickOpenModal(status:string, selectedItem:IStaff|null){
    let staff: IStaff|null = selectedItem;
    const dialogRef = this.dialog.open(StaffModalComponent, {
      width: '250px',
      data: staff
    });

    dialogRef.afterClosed().subscribe(result => {
      if(status=='post'){
        this.http.post(this.baseUrl+"staff", result).subscribe(answer=>{
          this.staffs.push(result);
        }, error=>{console.error(error)})
      }
      if(status=='put'){
        this.http.post(this.baseUrl+"staff", result).subscribe(answer=>{
          this.staffs.push(result);
        }, error=>{console.error(error)})
      }
    });
  }
}
