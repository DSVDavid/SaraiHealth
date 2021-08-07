import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from '@angular/common/http';
import { Injectable } from "@angular/core";
import { Observable } from 'rxjs';

@Injectable()
export class AuthInterceptor implements HttpInterceptor{
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        const my_token = localStorage.getItem("auth_token");

        if(my_token){
            const clone_req = req.clone({
                headers: req.headers.set("Authorization","Bearer "+my_token)
            })
           return next.handle(clone_req);
        }else{
           return next.handle(req);
        }
    }

}