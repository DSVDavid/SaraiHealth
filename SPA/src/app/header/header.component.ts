import { Component, OnInit } from '@angular/core';
import { DecodedToken } from '../models/DecodedToken';
import { AuthService } from '../services/auth.service';

@Component({
  selector: 'app-header',
  templateUrl: './header.component.html',
  styleUrls: ['./header.component.css']
})
export class HeaderComponent implements OnInit {

  public userInfo:DecodedToken;

  constructor(private authService:AuthService){}

    ngOnInit(): void {
     
      this.authService.tokenSubject.subscribe( (dt:DecodedToken) => {
        
        this.userInfo = dt;
      });
      if(this.authService.decodedToken){
        this.userInfo = {...this.authService.decodedToken};
      }
     

   
    }

    logOut(){
      this.authService.logout();
      
    }

}
