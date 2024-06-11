import {Component, Inject, inject} from '@angular/core';
import {MAT_DIALOG_DATA, MatDialogClose, MatDialogRef} from "@angular/material/dialog";
import {IStaff} from "../Interfaces/IStaff";
import {MatFormField} from "@angular/material/form-field";
import {FormsModule} from "@angular/forms";
import {MatInput} from "@angular/material/input";
// import { NgbActiveModal } from "@ng-bootstrap/ng-bootstrap";

@Component({
  selector: 'app-staff-modal',
  templateUrl: './staff-modal.component.html',
  styleUrls: ['./staff-modal.component.css'],
  standalone: true,
  imports: [
    MatFormField,
    FormsModule,
    MatDialogClose,
    MatInput
  ]
})
export class StaffModalComponent {
  constructor(public dialogRef: MatDialogRef<StaffModalComponent>, @Inject(MAT_DIALOG_DATA) public data: IStaff) {
  }
  onCloseClick(): void {
    this.dialogRef.close();
  }

  onSaveClick(){
    this.dialogRef.close(this.data);
  }
}
