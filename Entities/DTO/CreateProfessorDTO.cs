using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class CreateProfessorDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Study_Subject { get; set; }
        public List<Student> Students { get; set; }
        public Address Address { get; set; }
        public List<ProfessorSchool> ProfessorSchools { get; set; }
    }
}
