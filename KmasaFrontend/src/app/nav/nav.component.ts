import { AfterContentInit, Component, OnInit, ViewChild, ElementRef, ViewChildren, QueryList } from '@angular/core';
import { AuthenticationService } from '../_services/authentication.service';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css'],
  
})
export class NavComponent implements OnInit {

  isUserAuthenticated = localStorage.getItem("user");

  @ViewChild("navMenu", {static: true}) nav: ElementRef;
  @ViewChildren("profileNav") profileNavs: QueryList<ElementRef>;

  constructor(public authService: AuthenticationService) { }

  showMenu(): void{
    this.nav.nativeElement.classList.toggle('show');
  }

  ngOnInit(): void {
  }

  logout(){
    this.authService.logout();
  }

  showProfileMenu(){
    this.profileNavs.first.nativeElement.classList.toggle('open');
  }
}
