import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { RegisterComponent } from './register/register.component';
import { LoginComponent } from './login/login.component';
import { MentorsComponent } from './mentors/mentors.component';

const routes: Routes = [
  { path: "", component: HomeComponent},
  { path: "mentors", component: MentorsComponent},
  { path: 'mentors/:page/:pageSize', component: MentorsComponent},
  { path: "register", component: RegisterComponent},
  { path: "login", component: LoginComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
