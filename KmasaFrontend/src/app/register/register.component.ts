import { AfterViewInit, Component, ElementRef, OnInit, QueryList, ViewChild, ViewChildren } from '@angular/core';
import { AbstractControl, FormBuilder, FormControl, FormGroup, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { matchContent } from '../_extensions/match-validator';
import { AuthenticationService } from '../_services/authentication.service';
import { UserRegistrationDto } from '../_models/user-registration.dto';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit, AfterViewInit {
  submitted = false;
  credentials: FormGroup;
  validationErrors:string[] = [];

  @ViewChild("mentorTitle", {static: true}) mentorTitle: ElementRef;
  @ViewChild("studentCourse", {static: true}) studentCourse: ElementRef;
  @ViewChildren("tab") inputTabs: QueryList<ElementRef>;

  constructor(
    private formBuilder: FormBuilder,
    private router: Router,
    private authService: AuthenticationService) { }

  ngAfterViewInit(): void {
    console.log(this.inputTabs)
    this.inputTabs.first.nativeElement.classList.remove('tab-hidden');
  }

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
        (control: AbstractControl) => matchContent('password')
      ]),
      user: this.formBuilder.group({
        dateOfBirth: new FormControl(""),
        firstName: new FormControl("", [Validators.required, 
        Validators.minLength(3),
        Validators.maxLength(24)
        ]),
        lastName: new FormControl("", [Validators.required, 
        Validators.minLength(3),
        Validators.maxLength(24)
        ]),
        middleName: new FormControl("",[
        Validators.minLength(3),
        Validators.maxLength(24)
        ]),
        photo: this.formBuilder.group({
          id: new FormControl(0),
          url: new FormControl("")
          })
      }),
    });
  }

  register(): void{
    this.submitted = true;

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
    // if(this.credentials.controls['userName'].invalid && this.credentials.controls['userName'].touched){
    //   event.target.parentNode.parentNode.classList.add("invalid")
    // }
  }

  move(from: number, to: number){
    this.inputTabs.get(from - 1)?.nativeElement.classList.add('tab-hidden');
    this.inputTabs.get(to - 1)?.nativeElement.classList.remove('tab-hidden');
  }

}
