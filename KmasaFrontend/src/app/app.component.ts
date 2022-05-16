import { Component, AfterContentInit } from '@angular/core';
import {NgsRevealConfig} from 'ngx-scrollreveal';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css'],
  providers: [NgsRevealConfig]
})
export class AppComponent implements AfterContentInit {
  title = 'КмиСА';
  
  constructor(private config: NgsRevealConfig) {
    console.log(config)
   }

  ngAfterContentInit(): void {
    this.config.origin = 'top';
    this.config.distance = '80px';
    this.config.duration = 2000;
    this.config.reset = true;
  }
}
