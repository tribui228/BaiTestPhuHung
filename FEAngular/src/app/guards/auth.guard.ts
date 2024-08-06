import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot, CanActivate, CanActivateFn, GuardResult, MaybeAsync, Route, Router, RouterStateSnapshot } from '@angular/router';
import { AuthService } from '../services/auth.service';
import { NgToastService } from 'ng-angular-popup';
import { Title } from '@angular/platform-browser';
import { title } from 'process';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private auth : AuthService, private router: Router, private toast: NgToastService){} 

  canActivate():boolean{
    if(this.auth.isLoggedIn()){
      return true
    }else{     
      this.router.navigate(['login'])
      return false;
    }
  }
}

