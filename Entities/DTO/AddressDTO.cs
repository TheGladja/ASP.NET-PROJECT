using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class AddressDTO
    {
        public int Id { get; set; }
        public string City { get; set; }
        public int ProfessorId { get; set; }
        public string Street { get; set; }
        public int Postcode { get; set; }
        public AddressDTO(Address address)
        {
            this.Id = address.Id;
            this.ProfessorId = address.ProfessorId;
            this.City = address.City;
            this.Street = address.Street;
            this.Postcode = address.Postcode;
        }
    }
}
