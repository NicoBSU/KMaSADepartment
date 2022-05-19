import { Component, OnInit } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { MentorsService } from '../_services/mentors.service';
import { PagedModel } from '../_models/paged-model';
import { Mentor } from '../_models/mentor';
import { first, Subscription } from 'rxjs';

@Component({
  selector: 'app-mentors',
  templateUrl: './mentors.component.html',
  styleUrls: ['./mentors.component.css']
})
export class MentorsComponent implements OnInit {

  mentorsPagedModel: PagedModel<Mentor>;
  page: number = 1;
  pageSize: number = 10;
  private subscription: Subscription;

  constructor(
    private router: Router, 
    private activateRoute: ActivatedRoute,
    private mentorsService: MentorsService) {
      this.subscription = activateRoute.params.subscribe(params => this.page = params['page']);
      this.subscription = activateRoute.params.subscribe(params => this.pageSize = params['pageSize']);
     }

  ngOnInit(): void {
    this.getMentors();
  }

  getMentors(): void{
    
    if(this.page === undefined){
      this.page = 1;
    }
    if(this.pageSize === undefined){
      this.pageSize = 10;
    }

    this.mentorsService.getAll(this.page, this.pageSize)
        .pipe(first())
        .subscribe((model: PagedModel<Mentor>) => this.mentorsPagedModel = model);
  }

  rangeLinks(): number[]{
    return Array.from(Array(this.mentorsPagedModel.totalPages).keys()).map(x => x + 1)
  } 

}
