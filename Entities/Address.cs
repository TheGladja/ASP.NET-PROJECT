using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities
{
    public class Address
    {
        public int Id { get; set; }
        public int ProfessorId { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int Postcode { get; set; }
        public Professor Professor { get; set; }
    }
}
