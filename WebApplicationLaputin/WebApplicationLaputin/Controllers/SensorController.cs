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
    public class SensorController : ControllerBase
    {
        private readonly SensorRepository repository;

        public SensorController(SensorRepository repository)
        {
            this.repository = repository;
        }

        [Authorize]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [Authorize]
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

        [Authorize]
        [HttpGet("getByType")]
        public IActionResult GetByType(string type)
        {
            var result = repository.GetSensorsByType(type).Select(x => (SensorDto) x);
            var resultDTO = repository.GetByType(type);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize]
        [HttpGet("getByUnitId")]
        public IActionResult GetByUnitId(int unitid)
        {
            var result = repository.GetByUnitId(unitid);

            if (result == null)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] SensorDto dto)
        {
            return Ok(await repository.Create(dto));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] SensorDto dto, int id)
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
