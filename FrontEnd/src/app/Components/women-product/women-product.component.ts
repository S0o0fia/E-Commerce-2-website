import { Component, OnInit, Inject  } from '@angular/core';
import {MatPaginator , PageEvent} from '@angular/material/paginator';
 import {MatTableDataSource} from '@angular/material/table';
import {MatDialogRef , MatDialogConfig , MAT_DIALOG_DATA, MatDialog} from '@angular/material/dialog'
import { ProductDetailsComponent } from '../product-details/product-details.component';
import { Router } from '@angular/router';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';
@Component({
  selector: 'app-women-product',
  templateUrl: './women-product.component.html',
  styleUrls: ['./women-product.component.css']  

})
export class WomenProductComponent implements OnInit {
 
  constructor( private router : Router, public dialog: MatDialog ,private productservice : ProductService ){}
    id : number ;
    products :Product[];
    type : string;
    length : number; 
    pageSize : number ;
    pageIndex  = 0; 
    Data : Product[];
    event : PageEvent ;

   DirectDetails (id)
   { 
     this.type = "Women"

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
        this.pageIndex = event.pageIndex+event.pageSize;
     this.pageSize = event.pageSize;
    
     this.loadData(this.pageIndex , this.pageSize);

   }
  ngOnInit() {
    
    this.productservice.GetProduct(1).subscribe((data)=>
    {
      this.Data = data as Product [];
      this.length = this.Data.length;
      this.pageSize = this.Data.length /2;
      this.loadData(0 , this.pageSize);
     
    });
     
  
  }
   
 
}



