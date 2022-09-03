using ASP.NET_PROJECT.Entities;
using ASP.NET_PROJECT.Repositories.GenericRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Repositories.AddressRepository
{
    public interface IAddressRepository : IGenericRepository<Address>
    {
        Task<Address> GetAddressById(int id);
        Task<List<Address>> GetAddresses();
    }
}
