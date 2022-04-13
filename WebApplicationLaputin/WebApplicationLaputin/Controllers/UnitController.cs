using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.Dtos;
using WebApplicationLaputin.Repositories;

namespace WebApplicationLaputin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UnitController : ControllerBase
    {

        private readonly UnitRepository repository;

        public UnitController(UnitRepository repository)
        {
            this.repository = repository;
        }

        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            var result = repository.GetById(id);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UnitDto dto)
        {
            return Ok(await repository.Create(dto));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] UnitDto dto, int id)
        {
            var result = await repository.Update(dto, id);

            if (result == -1)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await repository.Delete(id);

            if (result == -1)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }
    }
}
