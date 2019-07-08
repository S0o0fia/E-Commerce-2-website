import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { City } from './city.model';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class CityService {

  constructor(private client : HttpClient) { }

  getcity (id)
  {
   let headers = new HttpHeaders().set('Content-Type', 'application/json');
   let params = new HttpParams().set('id' ,id);    
   return  this.client.get<City[]>(environment.apiBaseUrl+'/City/Get' , {params,headers});    
   } 
}
