using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities
{
    public class School
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public ICollection<ProfessorSchool> ProfessorSchools { get; set; }
    }
}
