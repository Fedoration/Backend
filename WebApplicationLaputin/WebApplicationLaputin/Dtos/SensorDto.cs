using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Dtos
{
    public class SensorDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Description { get; set; }
        public string Dimension { get; set; }
        public decimal Value { get; set; }
        public int UnitId { get; set; }
        public string UnitName { get; set; }

        public static explicit operator SensorDto (Sensor x)
        {
            return  new SensorDto
            {
                Id = x.Id,
                Name = x.Name,
                Type = x.Type,
                Description = x.Description,
                Dimension = x.Dimension,
                Value = x.Value,
                UnitId = x.UnitId,
                UnitName = x.Unit.Name
            };
        }
    }
}
