import { Component, OnInit } from '@angular/core';


import { Router } from '@angular/router';
import {PageEvent} from '@angular/material/paginator';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';

@Component({
  selector: 'app-men',
  templateUrl: './men.component.html',
  styleUrls: ['./men.component.css']
})
export class MenComponent implements OnInit {
  length : number; 
  pageSize : number ;
  pageIndex  = 0; 
  Data : Product[];
  event : PageEvent ;
  constructor(private router : Router ,private productservice : ProductService) { 
 
  

  }


   products :Product[];
   type : string;
 
   DirectDetails (id)
   { 
     this.type = "Men"

     this.router.navigate(['./productdeatils/'+this.type+'/'+id]);
   }
  
   loadData (pageIndex , pagesize)
   {
   
      this.products =   this.Data.slice(pageIndex, pageIndex+pagesize+1);
   }

   onPageChange(event)
   {
  
     if(this.pageIndex > 0 )
          this.pageIndex = 0 ;
    else
        this.pageIndex = (event.pageIndex+event.pageSize);
     this.pageSize = event.pageSize;
   
     this.loadData(this.pageIndex , this.pageSize);

   }
  ngOnInit() {
    
    this.productservice.GetProduct(2).subscribe((data)=>
    {
      this.Data = data as Product [];
      this.length = this.Data.length;
      this.pageSize = Math.round(this.Data.length /2)-1;
      this.loadData(0 , this.pageSize);
    });
     
      
  }
   
  
}
