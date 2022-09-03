using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities
{
    public class Student
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Avg_Grade { get; set; }
        public int ProfessorId { get; set; }
        public Professor Professor { get; set; }
    }
}
