using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.SchoolRepository
{
    public interface ISchoolRepository : IGenericRepository<School>
    {
        Task<School> GetSchoolWithName(string name);
        Task<School> GetSchoolById(int id);
        Task<List<School>> GetSchools();
    }
}
