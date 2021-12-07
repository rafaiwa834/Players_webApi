using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Pilkarze.Entities
{
    public class Club
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Nation { get; set; }
        public int PlayerId { get; set; }
        public bool Active { get; set; }
        public virtual Player Player { get; set; }

    }
}
