import { Component } from '@angular/core';
import { CampaignService } from './campaign/campaign.service';
import { ClientService } from './client/client.service';
import { MatDialog, MatSnackBar } from '@angular/material';

import { DialogAdd } from './campaign-add/campaign-add.component';
import { DialogDelete } from './campaign-delete/campaign-delete.component';
import { DialogEdit } from './campaign-edit/campaign-edit.component';

@Component({
  providers: [ CampaignService, ClientService, DialogAdd, DialogDelete, DialogEdit ],
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'Campaign App';
  private campaignData = [];
  private clientData = [];

  constructor(
    public dialog : MatDialog,
    private snackBar : MatSnackBar,
    private campaignService : CampaignService,
    private clientService : ClientService
    )
    {
      this.campaignService.getCampaigns().subscribe((response : any[]) => {
        this.campaignData = response;
      });
    }

    openEditDialog(id:number, name:string): void {
      const dialogRef = this.dialog.open(DialogEdit, {
        width: '250px',
        data: {Id: id, Name: name}
      });

      dialogRef.afterClosed().subscribe(result => {
        if(result){
          this.edit(result.Id, result.Name);
        }
      });
    }

    openDeleteDialog(id:number): void {
      const dialogRef = this.dialog.open(DialogDelete, {
        width: '250px',
        data: {Id: id}
      });

      dialogRef.afterClosed().subscribe(result => {
        if(result){
          this.delete(result.Id);
        }
      });
    }

    openAddDialog(): void {
      const dialogRef = this.dialog.open(DialogAdd, {
        width: '280px',
      });

      dialogRef.afterClosed().subscribe(result => {
        if(result){
          this.add(result);
        }
      });
    }

    openSnackBar(message:any){
      this.snackBar.open(message,"dismiss", {
        duration: 3000
      });
    }

    ngOnInit(){
      this.campaignService.getCampaigns().subscribe((response : any[]) => {
        this.campaignData = response;
      });

      this.clientService.getClients().subscribe((response : any[]) => {
        this.clientData = response;
      });
    }

    edit(id,campaign){
      this.campaignService.editCampaign(id, campaign).subscribe((response:any[]) => {
        console.log(response);
        this.openSnackBar(response);
        this.ngOnInit();
      });
    }

    delete(id){
      this.campaignService.deleteCampaign(id).subscribe((response:any[]) => {
        this.openSnackBar(response);
        this.ngOnInit();
      });
    }

    add(campaign){
      this.campaignService.createCampaign(campaign).subscribe((response:any[]) => {
        console.log(response);
        this.openSnackBar(response);

        this.ngOnInit();
      })
    }
}
