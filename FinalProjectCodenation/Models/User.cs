using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace FinalProjectCodenation.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string PassWord { get; set; }
        public string Role { get; set; }
        public bool Active { get; set; } = true;
        public int SectorId { get; set; }
        public Sector Sector { get; set; }
        public IEnumerable<Log> Logs { get; set; }


    }
}
