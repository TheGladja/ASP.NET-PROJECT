import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { SchoolDTO } from './SchoolDTO';
import { Observable} from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SchoolService {

  constructor(private http: HttpClient) { }

  getSchools() {
    return this.http.get<SchoolDTO[]>('https://localhost:44355/api/school');
  }

  getSchoolById(id: number) {
    return this.http.get<SchoolDTO>(`https://localhost:44355/api/school/${id}`);
  }

  getSchoolByName(name: string) {
    return this.http.get<SchoolDTO>(`https://localhost:44355/api/school/GetSchoolByName/${name}`);
  }

  deleteSchoolById(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/school/${id}`);
  }

  deleteAllSchools(): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/school`);
  }

  createSchool(name: string, rating: number): Observable<any> {
    return this.http.post<any>(`https://localhost:44355/api/school`, { name, rating });
  }
}
