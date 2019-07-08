import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { UserService } from 'src/app/shared/sharedUser/user.service';
import { Country } from 'src/app/shared/SharedCountry/country.model';
import { City } from 'src/app/shared/SharedCity/city.model';
import { CountryService } from 'src/app/shared/SharedCountry/country.service';
import { CityService } from 'src/app/shared/SharedCity/city.service';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-register-cutomer',
  templateUrl: './register-cutomer.component.html',
  styleUrls: ['./register-cutomer.component.css']
})
export class RegisterCutomerComponent implements OnInit {

  userForm: FormGroup;
  constructor(private route : Router ,private form: FormBuilder, private userservice: UserService, 
    private counttryservices : CountryService , private cityservice : CityService) { }
   country : Country[]=[];
   city : City[]=[];
   selectedCountry : string;
   selectedCity : string;

  ngOnInit() {
    this.userForm = this.form.group({
      fullName: ['', [Validators.required]],
      email: ['', [Validators.required , Validators.email] ],
      password: ['', [Validators.required , Validators.minLength(6)]],
      username: ['', [Validators.required ]],
      phone: ['', [Validators.required , Validators.maxLength(11) , Validators.maxLength(11) ]],
      city: ['', [Validators.required]] ,
      country: ['', [Validators.required]]
    });

    this.counttryservices.getcountry().subscribe(
     
      data =>{
        this.country = data as Country[];
        }
      , 
      err=> console.log(err)

    );}

    getCity(id)
    {
     this.selectedCountry = this.country[id-1].name;
      this.cityservice.getcity(id).subscribe(
        data=>this.city = data as City[] ,
        err=> console.log(err)
      )
    }

    getCty(id)
    {
    
      this.selectedCity = this.city[id-1].name;
    }

  onSubmit() {
    if(this.userForm.valid){

          this.userservice.selecteduser.country = this.selectedCountry;
          this.userservice.selecteduser.city = this.selectedCity;
          alert(this.userservice.selecteduser.country+ this.userservice.selecteduser.city);
            this.userservice.postUser(this.userservice.selecteduser).subscribe();
            this.route.navigate["/home"];
          
     }
  }
}
