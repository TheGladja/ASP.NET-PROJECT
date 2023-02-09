import { Component, OnInit } from '@angular/core';
import { RegisterService } from './register.service';

@Component({
  selector: 'app-register',
  template: `
    <form (ngSubmit)="register()">
      <input type="text" [(ngModel)]="username" name="username" placeholder="Username">
      <input type="text" [(ngModel)]="email" name="email" placeholder="Email">
      <input type="password" [(ngModel)]="password" name="password" placeholder="Password">
      <button type="submit">Register</button>
    </form>
    <div *ngIf="successMessage">
      {{ successMessage }}
    </div>
    <div *ngIf="errorMessage">
      {{ errorMessage }}
    </div>
  `,
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  username = '';
  email = '';
  password = '';
  successMessage = '';
  errorMessage = '';

  constructor(private registerService: RegisterService) { }

  ngOnInit() {
  }

  register() {
    this.registerService.register(this.username, this.email, this.password)
      .subscribe(
        result => {
          if (result) {
            this.successMessage = "User registered with success";
            setTimeout(() => {
              this.successMessage = '';
              window.location.reload();
            }, 3000);
          }
          else {
            this.errorMessage = "Error registering user";
            setTimeout(() => {
              this.errorMessage = '';
            }, 3000);
          }
        }
      );
  }
}
