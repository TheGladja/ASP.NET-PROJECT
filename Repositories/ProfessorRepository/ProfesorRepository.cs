using Microsoft.EntityFrameworkCore;
using ASP.NET_PROJECT.Data;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.ProfessorRepository
{
    public class ProfesorRepository : GenericRepository<Professor>, IProfessorRepository
    {
        public ProfesorRepository(ContextProiect context) : base(context) { }

        public async Task<Professor> GetProfessorByName(string last_name)
        {
            return await _context.Professors.Include(p => p.Address).Where(p => p.Last_Name.Equals(last_name)).FirstOrDefaultAsync();
        }

        public async Task<Professor> GetProfessorByIdWithAddress(int id)
        {
            return await _context.Professors.Include(p => p.Address).Where(p => p.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Professor>> GetProfessorsWithAddress()
        {
            return await _context.Professors.Include(p => p.Address).ToListAsync();
        }
    }
}
