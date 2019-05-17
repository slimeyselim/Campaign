import { Component, Inject, OnInit } from '@angular/core';
import { MatDialogRef, MAT_DIALOG_DATA} from '@angular/material';
import { ClientService } from '../client/client.service';
import {FormGroup, FormBuilder, Validator, Validators } from '@angular/forms';

@Component({
  providers: [ ClientService ],
  selector: 'campaign-add-dialog',
  templateUrl: 'campaign-add.dialog.html',
})
export class DialogAdd implements OnInit {
  clientNames:any;
  addForm: FormGroup;

  constructor(
    private clientService: ClientService,
    public dialogRef: MatDialogRef<DialogAdd>,
    private formBuilder : FormBuilder,
    @Inject(MAT_DIALOG_DATA) public data: any) {
       this.clientService.getClients().subscribe((response:any[]) => {
        this.clientNames = response;
      });
    }

  ngOnInit(){
    this.addForm = this.formBuilder.group({
      Name: ['', Validators.required],
      Type: ['', Validators.required],
      ClientId: ['', Validators.required],
      StartDate: ['', Validators.required],
      EndDate: ['', Validators.required]
    })
  }

  get name(){
    return this.addForm.get('Name');
  }

  get type(){
    return this.addForm.get('Type');
  }

  get clientId(){
    return this.addForm.get('ClientId');
  }

  get startDate(){
    return this.addForm.get('StartDate');
  }

  get endDate(){
    return this.addForm.get('EndDate');
  }

  save(){
    if(this.addForm.valid){
      this.dialogRef.close(this.addForm.value);
    }
  }

  onNoClick(): void {
    this.dialogRef.close();
  }
}
