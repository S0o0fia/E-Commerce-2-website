import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-home-page',
  templateUrl: './home-page.component.html',
  styleUrls: ['./home-page.component.css']
})
export class HomePageComponent implements OnInit {

 
  constructor(private router: Router) {}

  ngOnInit() {
  
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
}
