import { Component, OnInit, Input, ViewChild } from '@angular/core';

import { ActivatedRoute, Router  } from '@angular/router';
import { Product } from 'src/app/shared/sharedProduct/product.model';
import { ProductService } from 'src/app/shared/sharedProduct/product.service';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.css']
})
export class ProductDetailsComponent implements OnInit {
 
 
  constructor(private router : Router ,private productservice : ProductService , private route : ActivatedRoute ) { }
  
  product : Product;
  _id  : number;
  type : string;
  selectedqunatity : number;
   ngOnInit() { 
       this._id =  +(this.route.snapshot.paramMap.get("id"));
       this.type = (this.route.snapshot.paramMap.get("type"));
       this.productservice.GetSpecificProduct(this._id).subscribe((data)=>
       {
        this.product = data as Product ;
       });
     }
    
     AddtoCart()
     {
      sessionStorage.setItem(this._id.toString() , this.type);
      this.router.navigate(['/cart/'+this.selectedqunatity]);
     }
  
}
