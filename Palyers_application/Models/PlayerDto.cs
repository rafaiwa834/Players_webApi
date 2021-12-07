using Pilkarze.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Models
{
    public class PlayerDto
    {
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Goals { get; set; }
        public int TotalMatches { get; set; }
        public SoftClubDto CurrentClub { get; set; }
        public List<SoftClubDto> FormerClubs { get; set; }

    }
}
