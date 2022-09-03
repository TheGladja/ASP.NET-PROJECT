using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.StudentRepository
{
    public interface IStudentRepository : IGenericRepository<Student>
    {
        Task<Student> GetStudentByName(string last_name);
        Task<Student> GetStudentById(int id);
        Task<List<Student>> GetStudents();
    }
}
