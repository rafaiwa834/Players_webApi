using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Models
{
    public class UpdatePlayerDto
    {
        public string Nationality { get; set; }
        public string Position { get; set; }
        public int Goals { get; set; }
        public int TotalMatches { get; set; }
        public ClubDto currentClub { get; set; }
    }
}
