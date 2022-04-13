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
    public class ValveRepository
    {
        private readonly DbContextBase context;

        public ValveRepository(DbContextBase context)
        {
            this.context = context;
        }

        public IEnumerable<ValveDto> GetAll()
        {
            return context.Valves
                .Include(x => x.Unit)
                .Select(x => new ValveDto
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = x.Value,
                    UnitName = x.Unit.Name
                })
                .ToArray();
        }

        public ValveDto GetById(int id)
        {
            var valve = context.Valves
                .Include(x => x.Unit)
                .FirstOrDefault(x => x.Id == id);

            if (valve is null)
            {
                return null;
            }

            return new ValveDto
            {
                Name = valve.Name,
                Description = valve.Description,
                Value = valve.Value,
                UnitName = valve.Unit.Name
            };
        }

        public async Task<int> Create(ValveDto dto)
        {
            var unit = context.Units
                .FirstOrDefault(x => x.Name == dto.UnitName);

            if (unit is null)
            {
                return -1;
            }

            var valve = new Valve
            {
                Name = dto.Name,
                Description = dto.Description,
                Value = dto.Value,
                UnitId = unit.Id
            };

            context.Add(valve);
            await context.SaveChangesAsync();

            return valve.Id;
        }


        public async Task<int> Update(ValveDto dto, int id)
        {
            var unit = context.Units
                .FirstOrDefault(x => x.Name == dto.UnitName);

            if (unit is null)
            {
                return -1;
            }

            var valve = context.Valves
                .FirstOrDefault(x => x.Id == id);

            if (valve is null)
            {
                return -1;
            }

            valve.Name = dto.Name;
            valve.Description = dto.Description;
            valve.Value = dto.Value;
            valve.UnitId = unit.Id; 

            await context.SaveChangesAsync();

            return valve.Id;
        }


        public async Task<decimal> ChangeValue(int id, decimal value)
        {
            var valve = context.Valves
                   .FirstOrDefault(x => x.Id == id);
            if (valve is null)
            {
                return -1;
            }

            valve.Value = value;
            await context.SaveChangesAsync();

            return valve.Id;
        }


        public async Task<int> Delete(int id)
        {
            var valve = context.Valves
                .FirstOrDefault(x => x.Id == id);

            if (valve is null)
            {
                return -1;
            }

            context.Remove(valve);
            await context.SaveChangesAsync();

            return id;
        }
    }
}
