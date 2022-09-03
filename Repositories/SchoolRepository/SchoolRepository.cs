using Microsoft.EntityFrameworkCore;
using ASP.NET_PROJECT.Data;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.SchoolRepository
{
    public class SchoolRepository : GenericRepository<School>, ISchoolRepository
    {
        public SchoolRepository(ContextProiect context) : base(context) { }
        public async Task<School> GetSchoolById(int id)
        {
            return await _context.Schools.Where(s => s.Id == id).FirstOrDefaultAsync();
        }

        public async Task<School> GetSchoolWithName(string name)
        {
            return await _context.Schools.Where(s => s.Name.Equals(name)).FirstOrDefaultAsync();
        }

        public async Task<List<School>> GetSchools()
        {
            return await _context.Schools.ToListAsync();
        }
    }
}
