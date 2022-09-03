using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Entities.DTO;
using ASP.NET_PROJECT.Repositories.ProfessorRepository;
using ASP.NET_PROJECT.Repositories.StudentRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IStudentRepository _repository;
        private readonly IProfessorRepository _repProf;

        public StudentController(IStudentRepository repository, IProfessorRepository repProf)
        {
            _repository = repository;
            _repProf = repProf;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllStudents()
        {
            var students = await _repository.GetStudents();
            var studentsToReturn = new List<StudentDTO>();

            if (!students.Any())
            {
                return NotFound("There are no students left");
            }

            foreach (var student in students)
            {
                studentsToReturn.Add(new StudentDTO(student));
            }

            return Ok(studentsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudentById(int id)
        {
            var student = await _repository.GetStudentById(id);

            if (student == null)
            {
                return NotFound("Student does not exists");
            }

            return Ok(new StudentDTO(student));
        }

        [HttpGet]
        [Route("GetStudentByName/{last_name}")]
        public async Task<IActionResult> GetStudentByName(string last_name)
        {
            var student = await _repository.GetStudentByName(last_name);

            if (student == null)
            {
                return NotFound("Student does not exists");
            }

            return Ok(new StudentDTO(student));
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllStudents()
        {
            var students = await _repository.GetStudents();

            if (!students.Any())
            {
                return NotFound("There are no students left");
            }

            _repository.DeleteRange(students);

            await _repository.SaveAsync();

            return NoContent();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudentById(int id)
        {
            var student = await _repository.GetByIdAsync(id);

            if (student == null)
            {
                return NotFound("Student does not exists");
            }

            _repository.Delete(student);

            await _repository.SaveAsync();

            return NoContent();
        }

        [Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateStudent(CreateStudentDTO dto)
        {
            Student newStudent = new Student();

            newStudent.Id = dto.Id;
            newStudent.First_Name = dto.First_Name;
            newStudent.Last_Name = dto.Last_Name;
            newStudent.Avg_Grade = dto.Avg_Grade;
            newStudent.ProfessorId = dto.ProfessorId;
            newStudent.Professor = await _repProf.GetProfessorByIdWithAddress(newStudent.ProfessorId);

            if (newStudent.Professor == null)
            {
                return NotFound("Professor you want to assign does not exist");
            }

            _repository.Create(newStudent);

            await _repository.SaveAsync();

            return Ok(new StudentDTO(newStudent));
        }
    }
}
