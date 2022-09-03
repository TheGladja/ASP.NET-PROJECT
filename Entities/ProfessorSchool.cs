using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities
{
    public class ProfessorSchool
    {
        public int ProfessorId { get; set; }
        public int SchoolId { get; set; }
        public Professor Professor { get; set; }
        public School School { get; set; }
    }
}
