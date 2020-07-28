using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Models
{
    public class Log
    {
        public int Id { get; set; }
        public string Level { get; set; }
        public string Name { get; set; }
        public int Events { get; set; }
        public string Description { get; set; }
        public string Origin { get; set; }
        public string CreatedAt { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }

    }
}

