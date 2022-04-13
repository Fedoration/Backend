using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace WebApplicationLaputin.Models
{
    public class Valve
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Value { get; set; }

        public int UnitId { get; set; }
        [JsonIgnore]
        public Unit Unit { get; set; }
    }
}
