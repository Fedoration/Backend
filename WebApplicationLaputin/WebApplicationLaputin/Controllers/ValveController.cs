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
    public class ValveController : ControllerBase
    {

        private readonly ValveRepository repository;

        public ValveController(ValveRepository repository)
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

        [Authorize(Roles = "admin")]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] ValveDto dto)
        {
            return Ok(await repository.Create(dto));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] ValveDto dto, int id)
        {
            var result = await repository.Update(dto, id);

            if (result == -1)
            {
                return BadRequest(result);
            }

            return Ok(result);
        }

        [Authorize(Roles = "admin")]
        [HttpPut("change-value/{id}")]
        public async Task<IActionResult> UpdateValue([FromBody] decimal value, int id)
        {
            var result = await repository.ChangeValue(id, value);

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
