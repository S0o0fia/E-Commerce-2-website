import { Component, OnInit } from '@angular/core';
import { UserService} from './shared/sharedUser/user.service'

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers : [UserService]
})
export class AppComponent implements OnInit {
   constructor ()
   {
     
   }

  ngOnInit(): void {
   
  }
}
