import { Component, OnInit, Inject } from '@angular/core';
import {MatDialog, MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { DynamicFormService, DynamicFormControlModel } from "@ng-dynamic-forms/core";
import { FormGroup } from '@angular/forms';

export interface DialogModel{
  title: string;
  formModel: DynamicFormControlModel[];
  formGroup: FormGroup;
  index: number;
  ContextFormService: any;
}

@Component({
  selector: 'my-dialog',
  templateUrl: './dialog.component.html',
  styleUrls: ['./dialog.component.css']
})
export class DialogComponent implements OnInit {

  constructor(
    public dialogRef: MatDialogRef<DialogComponent>,
    @Inject(MAT_DIALOG_DATA) public data: DialogModel,
    private formService: DynamicFormService ) { }
  formGroup: FormGroup;
  ngOnInit(){
    this.formGroup = this.formService.createFormGroup(this.data.formModel);
    this.data.formGroup = this.formGroup;
  }
  onNoClick(): void {
    this.dialogRef.close();
  }
  sendData(){
    if (this.formGroup.valid) {
      this.dialogRef.close(this.data);
    }
    
  }

  onMatEvent($event) {
    if(this.data.ContextFormService.OnMatEvent){
      this.data.ContextFormService.OnMatEvent($event, this.data.formModel);
    }
    console.log(`Material ${$event.type} event on: ${$event.model.id}: `, $event);
  }

}
