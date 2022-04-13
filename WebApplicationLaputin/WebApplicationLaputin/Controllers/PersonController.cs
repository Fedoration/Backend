using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplicationLaputin.Models;
using WebApplicationLaputin.Repositories;

namespace WebApplicationLaputin.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PersonController : ControllerBase
    {
        private readonly PersonRepository repository;

        public PersonController(PersonRepository repository)
        {
            this.repository = repository;
        }

        [Authorize(Roles = "admin")]
        [HttpGet("all")]
        public IActionResult GetAll()
        {
            return Ok(repository.GetAll());
        }

        [Authorize(Roles = "admin")]
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
        public async Task<IActionResult> Create([FromBody] Person user)
        {
            return Ok(await repository.Create(user));
        }

        [Authorize(Roles = "admin")]
        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromBody] Person user, int id)
        {
            var result = await repository.Update(user, id);

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
