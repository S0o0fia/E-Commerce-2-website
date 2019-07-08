import { Component, OnInit, ElementRef, Input, ViewChild } from '@angular/core';

import { Router ,ActivatedRoute } from '@angular/router';
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';
import { User } from 'src/app/shared/sharedUser/user.model';
import { OrderService } from 'src/app/shared/sharedOrders/order.service';


@Component({
  selector: 'app-cart',
  templateUrl: './cart.component.html',
  styleUrls: ['./cart.component.css']
})
export class CartComponent implements OnInit {

  products :Array<Product> = [];
  Cat : Array<string> = [];
  totalPrice : number = 0;
  qunatity : number;
  user:User;
  constructor( private route : ActivatedRoute , private router  : Router,private productservice : ProductService ,
    private orderservice:OrderService) { }
 
  ngOnInit() {
      for (let i = 0; i < sessionStorage.length; i++){
      let key = sessionStorage.key(i);
      let value = sessionStorage.getItem(key);
      this.Cat[i] = value;
     this.productservice.GetSpecificProduct(+key).subscribe((data)=>
       {
        this.products[i] = data as Product ;
        this.totalPrice += this.products[i].price;
       });
     }      
    }
    Remove(i)
    {
     sessionStorage.removeItem(sessionStorage.key(i));
      window.location.reload();
     
    }

    GoToShop()
    {
      let lastlength =  sessionStorage.length;
       if(lastlength > 0 )
      {
      let path  = sessionStorage.getItem(sessionStorage.key(lastlength-1));
      this.router.navigate(['/'+ path.toLowerCase()]);
      }
      
      else
        this.router.navigate(['/home']);
     }
  
    
     Checkout()
     {
       
       this.user.email = localStorage.getItem("Email");
       if(localStorage.getItem("token")!=null)
       {
       this.orderservice.AddOrder(this.user).subscribe();
       }
     }
  }

   
   

