import { Component, OnInit } from '@angular/core';
import { SchoolService } from './SchoolService';
import { SchoolDTO } from './SchoolDTO';

@Component({
  selector: 'app-school',
  templateUrl: './school.component.html',
  styleUrls: ['./school.component.css']
})
export class SchoolComponent implements OnInit {
  schools: SchoolDTO[];
  selectedSchool: SchoolDTO;
  showSelectedSchool = false;

  constructor(private schoolService: SchoolService) { }

  ngOnInit() {
    this.getAllSchools();
  }

  getAllSchools() {
    this.schoolService.getSchools().subscribe(schools => {
      this.schools = schools;
    });
  }

  getSchoolById(id: number) {
    this.schoolService.getSchoolById(id).subscribe(school => {
      this.selectedSchool = school;
    });
  }

  getSchoolByName(name: string) {
    if (typeof name === 'string') {
      this.schoolService.getSchoolByName(name).subscribe(school => {
        this.selectedSchool = school;
      });
    }
  }

  deleteSchoolById(id: number) {
    this.schoolService.deleteSchoolById(id).subscribe();
    window.location.reload();
  }

  deleteAllSchools() {
    this.schoolService.deleteAllSchools().subscribe();
    window.location.reload();
  }

  createSchool(name: string, rating: number) {
    this.schoolService.createSchool(name, rating).subscribe();
    window.location.reload();
  }
}
