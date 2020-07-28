using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Models
{
    public class Sector
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public IEnumerable<User> Users { get; set; }

    }
}
