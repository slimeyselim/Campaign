import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';

@Injectable()
export class ClientService{
  baseUrl:string = "http://localhost:58385/api/client";

  headers:any = new HttpHeaders({
    'Context-Type' : 'application/json'
    });

  constructor(
    private http:HttpClient
  ){}

  getClients():any {
    return this.http.get(this.baseUrl);
  }
}
