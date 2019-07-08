import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';

import { Router } from '@angular/router';
import { UserService } from 'src/app/shared/sharedUser/user.service';

@Component({
  selector: 'app-login-customer',
  templateUrl: './login-customer.component.html',
  styleUrls: ['./login-customer.component.css']
})
export class LoginCustomerComponent implements OnInit {
  userForm: FormGroup;
  constructor(private router : Router,private form: FormBuilder, private userservice: UserService) { }

  ngOnInit() {
    this.userForm = this.form.group({
     
      Email: ['', [Validators.required , Validators.email] ],
      Password: ['', [Validators.required , Validators.minLength(6)]]
     
    });
  }
  onSubmit() {

    //
    if(this.userForm.valid){
      //alert(this.userservice.selecteduser.Email + this.userservice.selecteduser.Password);
       this.userservice.login(this.userservice.selecteduser).subscribe(
           (data)=>{
             
               
                localStorage.setItem('token'  , data.token); 
                localStorage.setItem('Email' , this.userservice.selecteduser.email);
                window.location.reload();

           } ,
         (err) => {console.log(err)}

       );
       this.router.navigate(['./home']);
    }


}

DirectRegister ()
  {
    this.router.navigate(['/register']);
  }
}
