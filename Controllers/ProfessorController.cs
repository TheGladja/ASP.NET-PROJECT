using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Entities.DTO;
using ASP.NET_PROJECT.Repositories.AddressRepository;
using ASP.NET_PROJECT.Repositories.ProfessorRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProfessorController : ControllerBase
    {
        private readonly IProfessorRepository _repository;

        public ProfessorController(IProfessorRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfessors()
        {
            var professors = await _repository.GetProfessorsWithAddress();
            var professorsToReturn = new List<ProfessorDTO>();

            if (!professors.Any())
            {
                return NotFound("There are no professors left");
            }

            foreach (var professor in professors)
            {
                professorsToReturn.Add(new ProfessorDTO(professor));
            }

            return Ok(professorsToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProfessorById(int id)
        {
            var professor = await _repository.GetProfessorByIdWithAddress(id);

            if (professor == null)
            {
                return NotFound("Professor does not exists");
            }

            return Ok(new ProfessorDTO(professor));
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpDelete]
        public async Task<IActionResult> DeleteAllProfesors()
        {
            var professors = await _repository.GetProfessorsWithAddress();

            if (!professors.Any())
            {
                return NotFound("There are no professors left");
            }

            _repository.DeleteRange(professors);

            await _repository.SaveAsync();

            return NoContent();
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProfessorById(int id)
        {
            var professor = await _repository.GetByIdAsync(id);

            if (professor == null)
            {
                return NotFound("Professor does not exists");
            }

            _repository.Delete(professor);


            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpGet]
        [Route("GetProfessorByName/{last_name}")]
        public async Task<IActionResult> GetProfessorByName(string last_name)
        {
            var professor = await _repository.GetProfessorByName(last_name);

            if (professor == null)
            {
                return NotFound("Professor does not exists");
            }

            return Ok(new ProfessorDTO(professor));
        }

        //[Authorize(Roles = UserRoles.Admin)]
        [HttpPost]
        public async Task<IActionResult> CreateProfessor(CreateProfessorDTO dto)
        {
            Professor newProfessor = new Professor();

            newProfessor.Id = dto.Id;
            newProfessor.First_Name = dto.First_Name;
            newProfessor.Last_Name = dto.Last_Name;
            newProfessor.Study_Subject = dto.Study_Subject;
            newProfessor.Address = dto.Address;
            newProfessor.Students = dto.Students;
            newProfessor.ProfessorSchools = dto.ProfessorSchools;

            _repository.Create(newProfessor);

            await _repository.SaveAsync();

            return Ok(new ProfessorDTO(newProfessor));
        }
    }
}
