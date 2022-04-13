using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.DbContextBases;
using WebApplicationLaputin.Dtos;
using WebApplicationLaputin.Models;

namespace WebApplicationLaputin.Repositories
{
    public class SensorRepository
    {
        private readonly DbContextBase context;

        public SensorRepository(DbContextBase context)
        {
            this.context = context;
        }

        public IEnumerable<SensorDto> GetAll()
        {
            return context.Sensors
                .Include(x => x.Unit)
                .Select(x=> new SensorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Description = x.Description,
                    Dimension = x.Dimension,
                    Value = x.Value,
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name
                })
                .ToArray();
        }

        public SensorDto GetById(int id)
        {
            var sensor = context.Sensors
                .Include(x => x.Unit)
                .FirstOrDefault(x => x.Id == id);

            if (sensor is null)
            {
                return null;
            }

            return new SensorDto
            {
                Id = sensor.Id,
                Name = sensor.Name,
                Type = sensor.Type,
                Description = sensor.Description,
                Dimension = sensor.Dimension,
                Value = sensor.Value,
                UnitId = sensor.UnitId,
                UnitName = sensor.Unit.Name
            };
        }

        public IEnumerable<SensorDto> GetByType(string type)
        {
            return context.Sensors
                .Include(x => x.Unit)
                .Where(x => x.Type == type)
                .Select(x => new SensorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Description = x.Description,
                    Dimension = x.Dimension,
                    Value = x.Value,
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name
                })
                .ToArray();

        }

        public IEnumerable<SensorDto> GetByUnitId(int unitid)
        {
            return context.Sensors
                .Include(x => x.Unit)
                .Where(x => x.UnitId == unitid)
                .Select(x => new SensorDto
                {
                    Id = x.Id,
                    Name = x.Name,
                    Type = x.Type,
                    Description = x.Description,
                    Dimension = x.Dimension,
                    Value = x.Value,
                    UnitId = x.UnitId,
                    UnitName = x.Unit.Name
                })
                .ToArray();

        }

        public async Task<int> Create(SensorDto dto)
        {
            var unit = context.Units
                .FirstOrDefault(x => x.Name == dto.UnitName);

            if (unit is null)
            {
                return -1;
            }

            var sensor = new Sensor
            {
                Name = dto.Name,
                Type = dto.Type,
                Description = dto.Description,
                Dimension = dto.Dimension,
                Value = dto.Value,
                UnitId = unit.Id
            };

            context.Add(sensor);
            await context.SaveChangesAsync();

            return sensor.Id;
        }


        public async Task<int> Update(SensorDto dto, int id)
        {
            var unit = context.Units
               .FirstOrDefault(x => x.Name == dto.UnitName);

            if (unit is null)
            {
                return -1;
            }

            var sensor = context.Sensors
                .FirstOrDefault(x => x.Id == id);

            if (sensor is null)
            {
                return -1;
            }

            sensor.Name = dto.Name;
            sensor.Type = dto.Type;
            sensor.Description = dto.Description;
            sensor.Dimension = dto.Dimension;
            sensor.Value = dto.Value;
            sensor.UnitId = unit.Id; 

            await context.SaveChangesAsync();

            return sensor.Id;
        }

        public async Task<decimal> ChangeValue(int id, decimal value)
        {
            var sensor = context.Sensors
                   .FirstOrDefault(x => x.Id == id);
            if (sensor is null)
            {
                return -1;
            }

            sensor.Value = value;
            await context.SaveChangesAsync();

            return sensor.Id;
        }

        public async Task<int> Delete(int id)
        {
            var sensor = context.Sensors
                .FirstOrDefault(x => x.Id == id);

            if (sensor is null)
            {
                return -1;
            }

            context.Remove(sensor);
            await context.SaveChangesAsync();

            return id;
        }
    }
}
