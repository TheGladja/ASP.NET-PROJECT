using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class CreateSchoolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public List<ProfessorSchool> ProfessorSchools { get; set; }
        public List<Student> Students { get; set; }
    }
}
