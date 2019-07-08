import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { PageEvent } from '@angular/material/paginator';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';

@Component({
  selector: 'app-others',
  templateUrl: './others.component.html',
  styleUrls: ['./others.component.css']
})
export class OthersComponent implements OnInit {
  constructor(private  router : Router,private productservice : ProductService) { 
 
  

  }
   products :Product[];
   type : string;
   length : number; 
   pageSize : number ;
   pageIndex  = 0; 
   Data : Product[];
   event : PageEvent ;
 
   DirectDetails (id)
   { 
     this.type = "Others"

     this.router.navigate(['./productdeatils/'+this.type+'/'+id]);
   }
   loadData (pageIndex , pagesize)
   {
     
      this.products =   this.Data.slice(pageIndex, pageIndex+pagesize+1);
   }

   onPageChange(event)
   {
  
     if(this.pageIndex == 0 )
     
     this.pageIndex = event.pageIndex+event.pageSize;
     else
     this.pageIndex = 0 ;
     this.pageSize = event.pageSize;
    
     this.loadData(this.pageIndex , this.pageSize);

   }
  ngOnInit() {
    
    this.productservice.GetProduct(4).subscribe((data)=>
    {
      this.Data = data as Product [];
      this.length = this.Data.length;
      this.pageSize = Math.round(this.Data.length /2);
      this.loadData(0 , this.pageSize);
    });
     
      
  }
   
  
}
