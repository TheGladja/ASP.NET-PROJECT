using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.ProfessorRepository
{
    public interface IProfessorRepository : IGenericRepository<Professor>
    {
        Task<Professor> GetProfessorByName(string last_name);
        Task<Professor> GetProfessorByIdWithAddress(int id);
        Task<List<Professor>> GetProfessorsWithAddress();
    }
}
