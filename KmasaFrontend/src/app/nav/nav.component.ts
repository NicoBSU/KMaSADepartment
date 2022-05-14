import { AfterContentInit, Component, OnInit, ViewChild, ElementRef } from '@angular/core';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

  @ViewChild("navMenu", {static: true}) nav: ElementRef;

  constructor() { }

  showMenu(): void{
    this.nav.nativeElement.classList.toggle('show');
  }

  ngOnInit(): void {
  }
}
