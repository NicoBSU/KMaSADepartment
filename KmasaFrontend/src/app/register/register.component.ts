import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { matchContent } from '../_extensions/match-validator';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  submitted = false;
  credentials: FormGroup;
  validationErrors:string[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService) { }

  ngOnInit(): void {
    this.credentials = this.formBuilder.group({
      userName: new FormControl("", [
        Validators.required, 
        Validators.email
      ]),
      password: new FormControl("", [
        Validators.required, 
        Validators.minLength(6), 
        Validators.maxLength(18)
      ]),
      confirmPassword: new FormControl("", [
        Validators.required, 
        matchContent("password")
      ])
    });
  }

  register(): void{
    this.submitted = true;

    if (this.credentials.invalid) {
        return;
    }

    this.authService.register(this.credentials.value).subscribe(
      {
        next: () => this.router.navigateByUrl(''),
        error: (e) => this.validationErrors = e,
        complete: () => this.router.navigateByUrl(''),
    })
  }

  addFocus(event: any): void{
    event.target.parentNode.parentNode.classList.add("focus")
    event.target.parentNode.parentNode.classList.remove("invalid")
  }

  removeFocus(event: any): void{
    if(event.target.value == ""){
      event.target.parentNode.parentNode.classList.remove("focus")
    }
    if(this.credentials.controls['userName'].invalid && this.credentials.controls['userName'].touched){
      event.target.parentNode.parentNode.classList.add("invalid")
    }
  }
}
