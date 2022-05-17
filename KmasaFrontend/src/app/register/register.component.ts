import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { matchContent } from '../_extensions/match-validator';
import { AuthenticationService } from '../_services/authentication.service';
import { UserRegistrationDto } from '../_models/user-registration.dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  submitted = false;
  credentials: UserRegistrationDto;
  validationErrors:string[] = [];

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService) { }

  ngOnInit(): void {
  }

  register(): void{
    this.submitted = true;


    this.authService.register(this.credentials).subscribe(
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
    // if(this.credentials.controls['userName'].invalid && this.credentials.controls['userName'].touched){
    //   event.target.parentNode.parentNode.classList.add("invalid")
    // }
  }
}
