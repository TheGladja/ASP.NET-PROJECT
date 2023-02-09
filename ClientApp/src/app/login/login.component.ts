import { Component } from '@angular/core';
import { LoginService } from './login.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  template: `
    <div *ngIf="!isLoggedIn">
      <form (ngSubmit)="login()">
        <input type="text" [(ngModel)]="username" name="username" placeholder="Username">
        <input type="password" [(ngModel)]="password" name="password" placeholder="Password">
        <button type="submit">Login</button>
      </form>
    </div>
    <div *ngIf="isLoggedIn" class="logged-in">
      <div class="username">Logged in as {{ storedUsername }}</div>
      <button (click)="logout()" class="logout-button">Logout</button>
    </div>
    <div *ngIf="errorMessage">
      {{ errorMessage }}
    </div>
  `,
  styleUrls: ['./login.component.css']
})
export class LoginComponent {
  username = '';
  password = '';
  isLoggedIn = false;
  errorMessage = '';
  storedUsername = '';

  constructor(private loginService: LoginService, private router: Router) { }

  ngOnInit() {
    this.isLoggedIn = localStorage.getItem('isLoggedIn') === 'true';
    this.storedUsername = localStorage.getItem('username');
  }

  login() {
    this.loginService.login(this.username, this.password).subscribe(result => {
      if (result) {
        this.isLoggedIn = true;
        localStorage.setItem('isLoggedIn', 'true');
        localStorage.setItem('username', this.username);
        this.storedUsername = this.username;
        window.location.reload();
        //this.router.navigate(['home']);
      } else {
        this.errorMessage = "Error logging user";
        setTimeout(() => {
          this.errorMessage = '';
        }, 3000);
      }
    });
  }

  logout() {
    this.isLoggedIn = false;
    localStorage.setItem('isLoggedIn', 'false');
    this.storedUsername = '';
    window.location.reload();
  }
}
