using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.V1.Dtos
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; } = true;
        public int SectorId { get; set; }
        public SectorDto Sector { get; set; }
        public IEnumerable<LogDto> Logs { get; set; }


    }
}
