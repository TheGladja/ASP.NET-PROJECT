import { Component, OnInit } from '@angular/core';
import { RegisterAdminService } from './registerAdmin.service';

@Component({
  selector: 'app-registerAdmin',
  template: `
    <form (ngSubmit)="registerAdmin()">
      <input type="text" [(ngModel)]="username" name="username" placeholder="Username">
      <input type="text" [(ngModel)]="email" name="email" placeholder="Email">
      <input type="password" [(ngModel)]="password" name="password" placeholder="Password">
      <button type="submit">Register Admin</button>
    </form>
    <div *ngIf="successMessage">
      {{ successMessage }}
    </div>
    <div *ngIf="errorMessage">
      {{ errorMessage }}
    </div>
  `,
  styleUrls: ['./registerAdmin.component.css']
})
export class RegisterAdminComponent implements OnInit {
  username = '';
  email = '';
  password = '';
  successMessage = '';
  errorMessage = '';

  constructor(private registerAdminService: RegisterAdminService) { }

  ngOnInit() {
  }

  registerAdmin() {
    this.registerAdminService.registerAdmin(this.username, this.email, this.password)
      .subscribe(
        result => {
          if (result) {
            this.successMessage = "Admin registered with success";
            setTimeout(() => {
              this.successMessage = '';
              window.location.reload();
            }, 3000);
          }
          else {
            this.errorMessage = "Error registering admin";
            setTimeout(() => {
              this.errorMessage = '';
            }, 3000);
          }
        }
      );
  }
}
