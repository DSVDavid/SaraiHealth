import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { DecodedToken } from './models/DecodedToken';
import { AuthService } from './services/auth.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
    constructor(authService:AuthService, router: Router){
      if(authService.getLoggedUser()){
        router.navigate(['/'+authService.getLoggedUser().role]);
      }else{
        router.navigate(['']);
      }
    }
}
