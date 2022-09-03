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
    public class AddressController : ControllerBase
    {
        private readonly IAddressRepository _repository;
        private readonly IProfessorRepository _repPr;

        public AddressController(IAddressRepository repository, IProfessorRepository repPr)
        {
            _repository = repository;
            _repPr = repPr;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAddresses()
        {
            var addresses = await _repository.GetAddresses();
            var addressesToReturn = new List<AddressDTO>();

            if (!addresses.Any())
            {
                return NotFound("There are no addresses left");
            }

            foreach (var address in addresses)
            {
                addressesToReturn.Add(new AddressDTO(address));
            }

            return Ok(addressesToReturn);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAddressById(int id)
        {
            var address = await _repository.GetAddressById(id);

            if (address == null)
            {
                return NotFound("Address does not exists");
            }

            return Ok(new AddressDTO(address));
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAllAddresses()
        {
            var addresses = await _repository.GetAddresses();

            if (!addresses.Any())
            {
                return NotFound("There are no addresses left");
            }

            var professors = await _repPr.GetProfessorsWithAddress();

            _repository.DeleteRange(addresses);
            _repPr.DeleteRange(professors);

            await _repository.SaveAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteAddressById(int id)
        {
            var address = await _repository.GetByIdAsync(id);

            if (address == null)
            {
                return NotFound("Address does not exists");
            }
            var professor = await _repPr.GetProfessorByIdWithAddress(address.ProfessorId);

            _repository.Delete(address);
            _repPr.Delete(professor);

            await _repository.SaveAsync();

            return NoContent();
        }
    }
}
