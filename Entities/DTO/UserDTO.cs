using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public UserDTO(ApplicationUser dto)
        {
            Id = dto.Id;
            Username = dto.UserName;
            Email = dto.Email;
        }
    }
}
