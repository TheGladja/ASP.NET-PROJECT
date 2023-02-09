import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { catchError, map, tap } from 'rxjs/operators';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
};

@Injectable({
  providedIn: 'root'
})
export class RegisterAdminService {
  private registerAdminUrl = 'https://localhost:44355/api/Authentication/RegisterAdmin';

  constructor(private http: HttpClient) { }

  registerAdmin(username: string, email: string, password: string): Observable<any> {
    return this.http.post<any>(this.registerAdminUrl, { username, email, password }, httpOptions)
      .pipe(
        catchError(this.handleError<any>('registerAdmin'))
      );
  }

  private handleError<T>(operation = 'operation', result?: T) {
    return (error: any): Observable<T> => {
      console.error(error);
      return of(result as T);
    };
  }
}
