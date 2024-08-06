import { HttpClient } from '@angular/common/http';
import { Inject, Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { PLATFORM_ID } from '@angular/core';
import { isPlatformBrowser } from '@angular/common';
import { BehaviorSubject } from 'rxjs';
@Injectable({
  providedIn: 'root'
})
export class AuthService {
  private baseUrl: string = 'https://localhost:44385/api/Auth/';
  isBrowser: boolean;
  public isAuth = new BehaviorSubject<boolean>(false);
  constructor(@Inject(PLATFORM_ID) platformId: Object,private http : HttpClient , private router : Router) { 
    this.isBrowser = isPlatformBrowser(platformId);
    this.autoSignIn();
  }
  autoSignIn() {
    if (this.isBrowser ? localStorage.getItem('token') : false) {
        this.isAuth.next(true);
        this.router.navigate(['/dashboard']);
    }
}
  signUp(userObj: any) {
    return this.http.post<any>(`${this.baseUrl}register`, userObj)
  }

  signIn(loginObj : any){
    return this.http.post<any>(`${this.baseUrl}login`,loginObj)
  }
  storeToken(tokenValue: string){
    if(true){
      localStorage.setItem('token', tokenValue)
    }
    
  }
  getToken(){
    if (this.isBrowser) { 
    return localStorage.getItem('token')
    }
    return "NotFound";
  }
  isLoggedIn(): boolean{
    if (this.isBrowser) {
    return !!localStorage.getItem('token')
    }
    return false
  }
  signOut(){
    if (this.isBrowser) {
    localStorage.clear();
    this.router.navigate(['login'])
    }
    return "NotFound";
  }
}
