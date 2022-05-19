import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { BehaviorSubject, Observable } from 'rxjs';
import {map} from 'rxjs/operators';
import { Router } from '@angular/router';
import { AuthUser } from '../_models/user-auth';
import { environment } from 'src/environments/environment';
import { UserRegistrationDto } from '../_models/user-registration.dto';
import { UserLoginDto } from '../_models/user-login.dto';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {
  private userSubject: BehaviorSubject<AuthUser>;
  public user: Observable<AuthUser>;

  constructor(private router: Router, private http: HttpClient) {
    this.userSubject = new BehaviorSubject<AuthUser>(JSON.parse(localStorage.getItem('user') || '{}'));
    this.user = this.userSubject.asObservable();
   }

   public get userValue(): AuthUser {
    return this.userSubject.value;
  }

  register(userCredentials: UserRegistrationDto) {
    return this.http.post<AuthUser>(`${environment.apiUrl}/account/register`, userCredentials)
    .pipe(map(user => {
      localStorage.setItem('user', JSON.stringify(user));
      this.userSubject.next(user);
  }));
  }

  login(userCredentials: UserLoginDto) {
    return this.http.post<AuthUser>(`${environment.apiUrl}/account/login`, userCredentials)
        .pipe(map(user => {
            localStorage.setItem('user', JSON.stringify(user));
            this.userSubject.next(user);
            return user;
        }));
  }

  logout() {
      localStorage.removeItem('user');
      this.router.navigate(['/login']);
  }
}
