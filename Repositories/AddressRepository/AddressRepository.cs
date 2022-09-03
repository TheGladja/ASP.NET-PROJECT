using Microsoft.EntityFrameworkCore;
using ASP.NET_PROJECT.Data;
using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.AddressRepository
{
    public class AddressRepository : GenericRepository<Address>, IAddressRepository
    {
        public AddressRepository(ContextProiect context) : base(context) { }
        public async Task<Address> GetAddressById(int id)
        {
            return await _context.Addresses.Where(a => a.Id == id).FirstOrDefaultAsync();
        }

        public async Task<List<Address>> GetAddresses()
        {
            return await _context.Addresses.ToListAsync();
        }
    }
}
