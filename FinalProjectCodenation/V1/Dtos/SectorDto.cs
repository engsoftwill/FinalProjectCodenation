using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.V1.Dtos
{
    public class SectorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<UserDto> Users { get; set; }

    }
}
