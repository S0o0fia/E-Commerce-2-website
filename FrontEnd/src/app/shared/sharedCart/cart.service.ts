import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Cart } from './cart.model';
import { environment } from 'src/environments/environment';


@Injectable({
  providedIn: 'root'
})
export class CartService {


  constructor(private client : HttpClient) { }
  postUser (cart : Cart)
  {
    let headers = new HttpHeaders();
    headers = headers.set('Authorization', `Bearer ${localStorage.getItem('token')}`,);
    return this.client.post(environment.apiBaseUrl+'/addtocart', cart , {headers});
   
  }
}
