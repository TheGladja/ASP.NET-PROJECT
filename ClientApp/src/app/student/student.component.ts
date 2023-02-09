import { Component, OnInit } from '@angular/core';
import { StudentService } from './StudentService';
import { StudentDTO } from './StudentDTO';

@Component({
  selector: 'app-student',
  templateUrl: './student.component.html',
  styleUrls: ['./student.component.css']
})
export class StudentComponent implements OnInit {
  students: StudentDTO[];
  selectedStudent: StudentDTO;
  showSelectedStudent = false;

  constructor(private studentService: StudentService) { }

  ngOnInit() {
    this.studentService.getStudents().subscribe(students => {
      this.students = students;
    });
  }

  getStudentById(id: number) {
    this.studentService.getStudentById(id).subscribe(student => {
      this.selectedStudent = student;
    });
  }

  getStudentByName(name: string) {
    if (typeof name === 'string') {
      this.studentService.getStudentByName(name).subscribe(student => {
        this.selectedStudent = student;
      });
    }
  }

  deleteStudentById(id: number) {
    this.studentService.deleteStudentById(id).subscribe();
    window.location.reload();
  }

  deleteAllStudents() {
    this.studentService.deleteAllStudents().subscribe();
    window.location.reload();
  }

  createStudent(firstName: string, lastName: string, avgGrade: number, professorId: number) {
    this.studentService.createStudent(firstName, lastName, avgGrade, professorId).subscribe();
    window.location.reload();
  }
}
