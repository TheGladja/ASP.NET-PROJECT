using Microsoft.EntityFrameworkCore;
using ASP.NET_PROJECT.Data;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.StudentRepository
{
    public class StudentRepository : GenericRepository<Student>, IStudentRepository
    {
        public StudentRepository(ContextProiect context) : base(context) { }
        public async Task<Student> GetStudentById(int id)
        {
            return await _context.Students.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<Student> GetStudentByName(string last_name)
        {
            return await _context.Students.Where(s => s.Last_Name.Equals(last_name)).FirstOrDefaultAsync();
        }

        public async Task<List<Student>> GetStudents()
        {
            return await _context.Students.ToListAsync();
        }
    }
}
