import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { UserDTO } from './UserDTO';
import { Observable, of } from 'rxjs';
import { catchError, map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root'
})
export class UserService {

  constructor(private http: HttpClient) { }

  getUsers() {
    return this.http.get<UserDTO[]>('https://localhost:44355/api/User');
  }

  getByUsername(Username: string) {
    return this.http.get<UserDTO>(`https://localhost:44355/api/User/GetByUsername/${Username}`);
  }

  updateUser(oldName: string, newName: string): Observable<string> {
    return this.http.post<void>(`https://localhost:44355/api/User/UpdateUsername/${oldName}/${newName}`, {})
      .pipe(
        map(() => 'User updated successfully'),
        catchError(error => {
          return of('Error updating user: ' + error.message);
        })
      );
  }

}
