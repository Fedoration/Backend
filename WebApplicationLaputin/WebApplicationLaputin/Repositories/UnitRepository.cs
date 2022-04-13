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
    public class UnitRepository
    {
        private readonly DbContextBase context;

        public UnitRepository(DbContextBase context)
        {
            this.context = context;
        }

        public IEnumerable<UnitDto> GetAll()
        {
            return context.Units
                .Select(x => new UnitDto
                {
                    Name = x.Name,
                    Description = x.Description,
                })
                .ToArray();
        }

        public UnitDto GetById(int id)
        {
            var unit = context.Units
                .FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                return null;
            }

            return new UnitDto
            {
                Name = unit.Name,
                Description = unit.Description,
            };
        }

        public async Task<int> Create(UnitDto dto)
        {

            var unit = new Unit
            {
                Name = dto.Name,
                Description = dto.Description,
            };

            context.Add(unit);
            await context.SaveChangesAsync();

            return unit.Id;
        }


        public async Task<int> Update(UnitDto dto, int id)
        {

            var unit = context.Units
                .FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                return -1;
            }

            unit.Name = dto.Name;
            unit.Description = dto.Description;

            await context.SaveChangesAsync();

            return unit.Id;
        }


        public async Task<int> Delete(int id)
        {
            var unit = context.Units
                .FirstOrDefault(x => x.Id == id);

            if (unit is null)
            {
                return -1;
            }

            context.Remove(unit);
            await context.SaveChangesAsync();

            return id;
        }
    }
}
