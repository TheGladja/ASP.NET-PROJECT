using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities
{
    public class Professor
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public string Study_Subject { get; set; }
        public ICollection<Student> Students { get; set; }
        public Address Address { get; set; }
        public ICollection<ProfessorSchool> ProfessorSchools { get; set; }
    }
}
