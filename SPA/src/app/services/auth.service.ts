import { AfterContentInit, Injectable, OnInit } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { JwtHelperService } from '@auth0/angular-jwt';
import { DecodedToken } from '../models/DecodedToken';
import { Router } from '@angular/router';
import { Subject } from 'rxjs';


const jwtHelper = new JwtHelperService();

@Injectable()
export class AuthService{
    
    //dev:44398
    //iis:5001
    //private baseLink = 'https://localhost:44398/api/users/';
    private baseLink = '/api/users/';
    public decodedToken:DecodedToken;
   
    public tokenSubject:Subject<DecodedToken> = new Subject<DecodedToken>();

    constructor(private httpClient: HttpClient, private router: Router){
        const my_token=localStorage.getItem("auth_token");
       
        if(my_token){
          
            this.decodedToken = jwtHelper.decodeToken(my_token);
            this.router.navigate(['/'+this.decodedToken.role]);
            this.tokenSubject.next({...this.decodedToken});
        }
        this.router.navigate(['/']);
    }

   
    

    login(email:string, password:string){
       this.httpClient.post(this.baseLink+'login', {email, password}).subscribe(resp => {
            this.decodedToken = jwtHelper.decodeToken(resp["token"]);
            console.log(this.decodedToken);
            localStorage.setItem('auth_token',resp["token"]);
            this.router.navigate(['/'+this.decodedToken.role]);
            this.tokenSubject.next({...this.decodedToken});
            
       },error => {
           console.log(error);
       });
    }

    logout(){
        this.decodedToken= null;
        localStorage.removeItem('auth_token');
        localStorage.removeItem('auth_meta');
        this.tokenSubject.next(null);

        this.router.navigate(['/']);
    }

    getLoggedUser(){
        if(this.decodedToken)
            return {...this.decodedToken};

        return null;
    }
}