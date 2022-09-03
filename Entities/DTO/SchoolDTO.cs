using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASP.NET_PROJECT.Entities.DTO
{
    public class SchoolDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Rating { get; set; }
        public SchoolDTO(School dto)
        {
            this.Id = dto.Id;
            this.Name = dto.Name;
            this.Rating = dto.Rating;
        }
    }
}
