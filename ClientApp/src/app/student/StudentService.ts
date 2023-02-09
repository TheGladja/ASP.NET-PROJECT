import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { StudentDTO } from './StudentDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class StudentService {

  constructor(private http: HttpClient) { }

  getStudents() {
    return this.http.get<StudentDTO[]>('https://localhost:44355/api/student');
  }

  getStudentById(id: number) {
    return this.http.get<StudentDTO>(`https://localhost:44355/api/student/${id}`);
  }

  getStudentByName(name: string) {
    return this.http.get<StudentDTO>(`https://localhost:44355/api/student/GetStudentByName/${name}`);
  }

  deleteStudentById(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/student/${id}`);
  }

  deleteAllStudents() {
    return this.http.delete<void>('https://localhost:44355/api/student');
  }

  createStudent(first_Name: string, last_Name: string, avg_Grade: number, professorId: number): Observable<any> {
    return this.http.post<any>(`https://localhost:44355/api/student`, { first_Name, last_Name, avg_Grade, professorId });
  }
}
