import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Router } from "@angular/router";
import { Mentor } from "../_models/mentor";
import { PagedModel } from '../_models/paged-model';

import { environment } from 'src/environments/environment';

@Injectable({
    providedIn: 'root'
  })
  export class MentorsService {
      private apiUrl: string = "/mentors";

      constructor(private router: Router, private http: HttpClient) {
       }
    
      getAll(currentPage: number, pageSize: number) {
        return this.http.get<PagedModel<Mentor>>(`${environment.apiUrl}${this.apiUrl}/${currentPage}/${pageSize}`);
      }
  }