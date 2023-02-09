import { Component, OnInit } from '@angular/core';
import { ProfessorService } from './ProfessorService';
import { ProfessorDTO } from './ProfessorDTO';

@Component({
  selector: 'app-professor',
  templateUrl: './professor.component.html',
  styleUrls: ['./professor.component.css']
})
export class ProfessorComponent implements OnInit {
  professors: ProfessorDTO[];
  selectedProfessor: ProfessorDTO;
  showSelectedProfessor = false;

  constructor(private professorService: ProfessorService) { }

  ngOnInit() {
    this.professorService.getProfessors().subscribe(professors => {
      this.professors = professors;
    });
  }

  getProfessorById(id: number) {
    this.professorService.getProfessorById(id).subscribe(professor => {
      this.selectedProfessor = professor;
    });
  }

  getProfessorByName(name: string) {
    if (typeof name === 'string') {
      this.professorService.getProfessorByName(name).subscribe(professor => {
        this.selectedProfessor = professor;
      });
    }
  }

  deleteProfessorById(id: number) {
    this.professorService.deleteProfessorById(id).subscribe();
    window.location.reload();
  }

  deleteAllProfessors() {
    this.professorService.deleteAllProfessors().subscribe();
    window.location.reload();
  }

  createProfessor(first_name: string, last_name: string, study_subject: string, city: string, street: string, postcode: number) {
    this.professorService.createProfessor(first_name, last_name, study_subject, city, street, postcode).subscribe();
    window.location.reload();
  }
}
