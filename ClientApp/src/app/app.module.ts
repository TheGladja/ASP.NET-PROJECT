import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { RouterModule } from '@angular/router';
import { AppComponent } from './app.component';
import { NavMenuComponent } from './nav-menu/nav-menu.component';
import { HomeComponent } from './home/home.component';
import { ProfessorComponent } from './professor/professor.component';
import { AddressComponent } from './address/address.component';
import { StudentComponent } from './student/student.component';
import { SchoolComponent } from './school/school.component';
import { UserComponent } from './user/user.component';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';
import { RegisterAdminComponent } from './registerAdmin/registerAdmin.component';
import { AuthGuardService } from './authGuard/auth.guard';

@NgModule({
  declarations: [
    AppComponent,
    NavMenuComponent,
    HomeComponent,
    ProfessorComponent,
    AddressComponent,
    StudentComponent,
    SchoolComponent,
    UserComponent,
    LoginComponent,
    RegisterComponent,
    RegisterAdminComponent
  ],
  providers: [AuthGuardService],
  imports: [
    BrowserModule.withServerTransition({ appId: 'ng-cli-universal' }),
    HttpClientModule,
    FormsModule,
    RouterModule.forRoot([
      { path: '', redirectTo: '/login', pathMatch: 'full' },
      { path: 'home', component: HomeComponent, canActivate: [AuthGuardService]},
      { path: 'professor', component: ProfessorComponent, canActivate: [AuthGuardService]},
      { path: 'address', component: AddressComponent, canActivate: [AuthGuardService]},
      { path: 'student', component: StudentComponent, canActivate: [AuthGuardService]},
      { path: 'school', component: SchoolComponent, canActivate: [AuthGuardService]},
      { path: 'user', component: UserComponent, canActivate: [AuthGuardService]},
      { path: 'login', component: LoginComponent },
      { path: 'register', component: RegisterComponent },
      { path: 'registerAdmin', component: RegisterAdminComponent }
    ])
  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
