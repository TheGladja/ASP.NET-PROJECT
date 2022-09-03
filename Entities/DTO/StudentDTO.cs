using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class StudentDTO
    {
        public int Id { get; set; }
        public string First_Name { get; set; }
        public string Last_Name { get; set; }
        public int Avg_Grade { get; set; }
        public int ProfessorId { get; set; }
        public StudentDTO(Student student)
        {
            this.Id = student.Id;
            this.First_Name = student.First_Name;
            this.Last_Name = student.Last_Name;
            this.Avg_Grade = student.Avg_Grade;
            this.ProfessorId = student.ProfessorId;
        }
    }
}
