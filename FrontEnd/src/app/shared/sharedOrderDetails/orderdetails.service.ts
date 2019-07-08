import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { environment } from 'src/environments/environment';
import { Orderdetails } from './orderdetails.model';

@Injectable({
  providedIn: 'root'
})
export class OrderdetailsService {

  constructor(private client : HttpClient) { }
  getOrders (id )
  {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    let params = new HttpParams().set('_id' , id);
    return this.client.get<Orderdetails[]>(environment.apiBaseUrl+'/OrderDetails', { headers , params});
  }

}
