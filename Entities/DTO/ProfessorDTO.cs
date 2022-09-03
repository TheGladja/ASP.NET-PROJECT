using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class ProfessorDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Study_Subject { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public int PostCode { get; set; }
        public ProfessorDTO(Professor profesor)
        {
            this.Id = profesor.Id;
            this.First_Name = profesor.First_Name;
            this.Last_Name = profesor.Last_Name;
            this.Study_Subject = profesor.Study_Subject;
            this.City = profesor.Address.City;
            this.Street = profesor.Address.Street;
            this.PostCode = profesor.Address.Postcode;
        }
    }
}
