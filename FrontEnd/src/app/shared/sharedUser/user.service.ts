import { Injectable } from '@angular/core';
import {User} from './user.model'
import { HttpClient , HttpHandler  , HttpHeaders, HttpParams} from '@angular/common/http'
import { environment } from 'src/environments/environment';
import { Observable } from 'rxjs';
import { pipe } from '@angular/core/src/render3';
import { Token } from '../../shared/sharedToken/token.model';
import { Text } from '@angular/compiler';
import { TokenType } from '@angular/compiler/src/ml_parser/lexer';
@Injectable({
  providedIn: 'root'
})
export class UserService {

  selecteduser : User ={
    fullName : "" ,
    username :"",
    email :"",
    password : "",
    phoneNumber : "",
    country : "" , 
   city : ""
   };

 constructor( private client : HttpClient) { }
  
   postUser (user : User)
   {
     let headers = new HttpHeaders();
     headers = headers.set('Content-Type', 'application/json; charset=utf-8');
     return this.client.post(environment.apiBaseUrl+'/Account/Register', user , {headers});    
   }


   login (user : User):Observable<Token>
   {
    
     let headers = new HttpHeaders();
     headers = headers.set('Content-Type', 'application/json; charset=utf-8');
     return this.client.post<Token>(environment.apiBaseUrl+'/Account/Login', user , {headers});   
     

   }

   
   getCustomer ()
   {
    let headers = new HttpHeaders().set('Content-Type', 'application/json');
    let params = new HttpParams().set('Email' , localStorage.getItem('Email'));    
    return  this.client.get<User>(environment.apiBaseUrl+'/Account/Profile' , {params,headers});    
    } 

}
