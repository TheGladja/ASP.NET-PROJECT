using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Entities.DTO;
using ASP.NET_PROJECT.Repositories.SchoolRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SchoolController : ControllerBase
    {
        private readonly ISchoolRepository _repository;

        public SchoolController(ISchoolRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllSchools()
        {
            var schools = await _repository.GetSchools();
            var schoolsToReturn = new List<SchoolDTO>();

            if (!schools.Any())
            {
                return NotFound("There are no schools left");
            }

            foreach (var school in schools)
            {
                schoolsToReturn.Add(new SchoolDTO(school));
            }

            return Ok(schoolsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSchoolById(int id)
        {
            var school = await _repository.GetSchoolById(id);

            if (school == null)
            {
                return NotFound("School does not exists");
            }

            return Ok(new SchoolDTO(school));
        }

        [HttpGet]
        [Route("GetSchoolByName/{name}")]
        public async Task<IActionResult> GetSchoolByName(string name)
        {
            var school = await _repository.GetSchoolWithName(name);

            if (school == null)
            {
                return NotFound("School does not exists");
            }

            return Ok(new SchoolDTO(school));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllSchools()
        {
            var schools = await _repository.GetSchools();

            if (!schools.Any())
            {
                return NotFound("There are no schools left");
            }

            _repository.DeleteRange(schools);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSchoolById(int id)
        {
            var school = await _repository.GetByIdAsync(id);

            if (school == null)
            {
                return NotFound("School does not exists");
            }

            _repository.Delete(school);

            await _repository.SaveAsync();

            return NoContent();
        }
        [HttpPost]
        public async Task<IActionResult> CreateSchool(CreateSchoolDTO dto)
        {
            School newSchool = new School();

            newSchool.Id = dto.Id;
            newSchool.Name = dto.Name;
            newSchool.Rating = dto.Rating;
            newSchool.ProfessorSchools = dto.ProfessorSchools;

            _repository.Create(newSchool);

            await _repository.SaveAsync();

            return Ok(new SchoolDTO(newSchool));
        }
    }
}
