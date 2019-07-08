import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Country } from './country.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CountryService {

  constructor(private client : HttpClient) { }

  getcountry ()
  {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    return  this.client.get<Country[]>(environment.apiBaseUrl+'/Country/Get' , {headers});    
   } 
}
