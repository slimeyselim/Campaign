import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpErrorResponse } from '@angular/common/http';

@Injectable()
export class CampaignService{
  baseUrl:string = "http://localhost:58385/api/campaign";

  headers:any = new HttpHeaders({
    'Content-Type' : 'application/json'
    });

  constructor(
    private http:HttpClient
  ){}

  getCampaigns():any {
    return this.http.get(this.baseUrl);
  }

  editCampaign(id:number, name:any):any{
    return this.http.put(this.baseUrl + '/' + id, JSON.stringify(name),
    {
      headers : this.headers
    })
  }

  deleteCampaign(id:number):any{
    return this.http.delete(this.baseUrl + '/' + id);
  }

  createCampaign(campaign:any):any{
    return this.http.post(this.baseUrl,campaign)
  }
}
