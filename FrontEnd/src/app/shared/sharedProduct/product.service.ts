import { Injectable } from '@angular/core';
import { HttpClient, HttpParams, HttpHeaders } from '@angular/common/http';
import { Product } from './product.model';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class ProductService {
   
    Products : Observable<Product[]>;   
  constructor(private client : HttpClient) { }

  GetProduct (id)
  {
    
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    let params = new HttpParams().set('id' , id);
    
     return  this.client.get<Product[]>(environment.apiBaseUrl+'/Product/Get' , {params,headers});
  }


  GetSpecificProduct(id)
  {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    let params = new HttpParams().set('id' , id);    
    return  this.client.get<Product>(environment.apiBaseUrl+'/Product/GetOne' , {params,headers});
  }
  
}

