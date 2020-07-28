using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.V1.Dtos
{
    public class LogDto
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public int Events { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string CreatedAt { get; set; }
        public UserDto User { get; set; }
        public int UserId { get; set; }

    }
}

