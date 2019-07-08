import { Component, OnInit } from '@angular/core';

import {MatPaginator , PageEvent} from '@angular/material/paginator';
import { AlertPromise } from 'selenium-webdriver';
import { MatDialog } from '@angular/material/dialog';
import { Orders } from 'src/app/shared/sharedOrders/orders.model';
import { Orderdetails } from 'src/app/shared/sharedOrderDetails/orderdetails.model';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { OrderService } from 'src/app/shared/sharedOrders/order.service';
import { OrderdetailsService } from 'src/app/shared/sharedOrderDetails/orderdetails.service';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';

@Component({
  selector: 'app-orders',
  templateUrl: './orders.component.html',
  styleUrls: ['./orders.component.css']
})
export class OrdersComponent implements OnInit {

    orders : Orders[]=[] ; 
    ordersDeatils : Orderdetails[]=[];
    product: Product;
    products : Product[]=[];
    totalprice: number = 0;
    length : number; 
    pageSize : number ;
    pageIndex  = 0; 
    event : PageEvent ;
    productlength : number;

  constructor(public dialog: MatDialog , private orderService : OrderService , private orderDetailService : OrderdetailsService , 
    private productservice : ProductService ) { }

  ngOnInit() {
 
    this.orderService.getOrders(localStorage.getItem("Email")).subscribe(
     data => {this.orders = data as Orders[];
      this.orders.forEach(element => {   
           
        
        this.orderDetailService.getOrders(element._id).subscribe(
         data1=>{
            
            this.ordersDeatils= data1;
        
          this.ordersDeatils.forEach(element => {
            
          
            this.productservice.GetSpecificProduct(element.ProductId).subscribe(
                   data2 =>{
                     this.products.push(data2);
                     this.totalprice += this.products.pop().price * element.Quantity ;
                    
                     } ,
                   err => {console.log(err);}
            );
          });
          } ,
         err => console.log(err));
        });
     
      } , 
     err => {console.log(err);}
  );
    
  

  }


  
  onPageChange(event)
  {
 
    this.pageIndex = event.pageIndex;
    this.pageSize = event.pageSize;
   
    

  }
}
