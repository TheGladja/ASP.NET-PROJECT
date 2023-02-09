import { Component, OnInit } from '@angular/core';
import { UserService } from './UserService';
import { UserDTO } from './UserDTO';

@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})
export class UserComponent implements OnInit {
  users: UserDTO[];
  selectedUser: UserDTO;

  constructor(private userService: UserService) { }

  ngOnInit() {
    this.userService.getUsers().subscribe(users => {
      this.users = users;
    });
  }

  getByUsername(Username: string) {
    if (typeof Username === 'string') {
      this.userService.getByUsername(Username).subscribe(user => {
      this.selectedUser = user;
    });
    }
  }

  updateUser(oldName: string, newName: string) {
    this.userService.updateUser(oldName, newName).subscribe();
    window.location.reload();
  }
}
