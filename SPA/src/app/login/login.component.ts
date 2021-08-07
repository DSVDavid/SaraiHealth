import { Component, OnInit } from '@angular/core';
import { MatCard } from '@angular/material/card';
import { NgForm } from '@angular/forms';
import { AuthService } from '../services/auth.service';
import { JwtHelperService } from '@auth0/angular-jwt';

const jwt = new JwtHelperService();

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  constructor(private authService: AuthService) { }

  ngOnInit(): void {

  }

  onSubmit(f:NgForm){
   
    this.authService.login(f.value.email,f.value.pass)
  }

}
