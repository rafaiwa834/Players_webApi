using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Pilkarze.Models
{
    public class CreatePlayerDto
    {
        [MaxLength(20)]
        public string Nationality { get; set; }
        [MaxLength(20)]
        public string Position { get; set; }
        [MaxLength(20)]
        public string Name { get; set; }
        [MaxLength(20)]
        public string SecondName { get; set; }
        public int Goals { get; set; }
        public int TotalMatches { get; set; }
        public List<ClubDto> Clubs { get; set; }

    }
}
