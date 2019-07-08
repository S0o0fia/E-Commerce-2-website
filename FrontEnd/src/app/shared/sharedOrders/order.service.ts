import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Orders } from './orders.model';
import { environment } from 'src/environments/environment';
import { User } from '../sharedUser/user.model';

@Injectable({
  providedIn: 'root'
})
export class OrderService {

  constructor(private client : HttpClient) { }
  getOrders (Email)
  {

    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    let params = new HttpParams().set('Email' , Email );
    return this.client.get<Orders[]>(environment.apiBaseUrl+'/Orders', { params ,  headers});
  }

  AddOrder(user:User)
  {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    return this.client.post(environment.apiBaseUrl+'/Order/Add', user, { headers});

  }
}
