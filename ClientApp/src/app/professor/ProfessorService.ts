import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { ProfessorDTO } from './ProfessorDTO';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ProfessorService {

  constructor(private http: HttpClient) { }

  getProfessors() {
    return this.http.get<ProfessorDTO[]>('https://localhost:44355/api/professor');
  }

  getProfessorById(id: number) {
    return this.http.get<ProfessorDTO>(`https://localhost:44355/api/professor/${id}`);
  }

  getProfessorByName(name: string) {
    return this.http.get<ProfessorDTO>(`https://localhost:44355/api/professor/GetProfessorByName/${name}`);
  }

  deleteProfessorById(id: number): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/professor/${id}`);
  }

  deleteAllProfessors(): Observable<void> {
    return this.http.delete<void>(`https://localhost:44355/api/professor`);
  }

  createProfessor(first_name: string, last_name: string, study_subject: string, city: string, street: string, postcode: number): Observable<any> {
    let address = { city: city, street: street, postcode: postcode };
    return this.http.post<any>(`https://localhost:44355/api/professor`, {first_name, last_name, study_subject, address});
  }
}
