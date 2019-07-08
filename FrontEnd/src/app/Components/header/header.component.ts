import { Component, OnInit } from '@angular/core';
import {Router} from '@angular/router';


@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css'] , 
  
})
export class HeaderComponent implements OnInit {

  constructor(private router: Router) { }
  login : string="";
  signup : string="";
  ngOnInit() {
    if(localStorage.length == 0)
    {
      this.login = "Login";
      this.signup = "SignUp";
      
    }
    else if(localStorage.length > 0)
    {
           this.login = "Logout";
           this.signup = "Profile";
           
    }
  }

  DirectWomen ()
  {
    this.router.navigate(['./women']);
  }

  DirectMen ()
  {
    this.router.navigate(['./men']);
  }

  DirectKids ()
  {
    this.router.navigate(['./kids']);
  }

  DirectOthers ()
  {
    this.router.navigate(['./others']);
  }

  DirectLogin ()
  {
    if(localStorage.length == 0)
    {
     
       this.router.navigate(['./login']);
       
      
    }
    else if(localStorage.length > 0)
    {
      this.login = "Login";
      this.signup = "SignUp";
      localStorage.removeItem('token');
      localStorage.removeItem('Email');
      this.router.navigate(['./home']);
     
      
           
    }

  }

  DirectRegister ()
  {

    if(localStorage.length > 0)
    this.router.navigate(['/profile']);
    else
    this.router.navigate(['/register']);
  
  }

  DirectCart ()
  {
    this.router.navigate(['/cart']);
  }
}
