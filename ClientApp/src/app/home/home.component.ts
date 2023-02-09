import { Component, OnInit } from '@angular/core';
import { ProfessorService } from '../professor/ProfessorService';
import { ProfessorDTO } from '../professor/ProfessorDTO';
import { StudentDTO } from '../student/StudentDTO';
import { StudentService } from '../student/StudentService';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit{
  professors: ProfessorDTO[];
  students: StudentDTO[];
 
  constructor(private professorService: ProfessorService,private studentService: StudentService) { }

  ngOnInit() {
    this.getAllProfessors();
    this.getAllStudents();
  }
  getAllProfessors() {
    this.professorService.getProfessors().subscribe(professors => {
      this.professors = professors;
    });
  }
  getAllStudents() {
    this.studentService.getStudents().subscribe(students => {
      this.students = students;
    });
  }
}
