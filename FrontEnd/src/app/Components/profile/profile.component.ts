import { Component, OnInit } from '@angular/core';

import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/sharedUser/user.service';
import { User } from 'src/app/shared/sharedUser/user.model';


@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.css']
})
export class ProfileComponent implements OnInit {

  user : User; 
  constructor( private userservice : UserService , private route :Router) { }

  ngOnInit() {
     this.userservice.getCustomer().subscribe(
       data => {this.user = data;
      
      } , 
       err => {console.log(err);}

     );
    
   
}

}
