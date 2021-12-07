using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pilkarze.Entities
{
    public class Player
    {
        public string Nationality { get; set; }
        public string Position { get; set; }
        public string Name { get; set; }
        public string SecondName { get; set; }
        public int Goals { get; set; }
        public int TotalMatches { get; set; }
        public int PlayerId { get; set; }
        public List<Club> Clubs { get; set; }

    }
}
