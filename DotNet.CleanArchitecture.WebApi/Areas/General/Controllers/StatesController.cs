using DotNet.CleanArchitecture.Model.Common;
using DotNet.CleanArchitecture.Model.Entity.General;
using DotNet.CleanArchitecture.Model.Interfaces.General;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DotNet.CleanArchitecture.WebApi.Areas.General.Controllers
{
    [Route("[area]/api/[controller]")]
    [ApiController]
    [Area(Constants.AREA_GENERAL)]
    public class StatesController : ControllerBase
    {
        private readonly IStateBusiness _business;

        public StatesController(IStateBusiness business)
        {
            _business = business;
        }

        // GET: General/api/States
        [HttpGet]
        public async Task<ActionResult<IEnumerable<State>>> Get()
        {
            try
            {
                return await _business.ReadAllAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: General/api/States/COL-05
        [HttpGet("{code}")]
        public async Task<ActionResult<State>> Get(string code)
        {
            try
            {
                var entity = await _business.ReadAsync(code);
                if (entity == null)
                {
                    return NotFound();
                }
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // GET: General/api/States/Country/COL
        [HttpGet("Country/{countryCode}")]
        public async Task<ActionResult<IEnumerable<State>>> GetByCountryCode(string countryCode)
        {
            try
            {
                return await _business.ReadAllAsync(countryCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: General/api/States/COL-05
        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] State entity)
        {
            try
            {
                if (code != entity.StateCode)
                {
                    return BadRequest();
                }
                await _business.UpdateAsync(code, entity);
                return Ok(entity);
            }
            catch (Exception)
            {

                throw;
            }
        }

        // POST: General/api/States
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] State entity)
        {
            try
            {
                await _business.CreateAsync(entity.StateCode, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: General/api/States/COL-05
        [HttpDelete("{code}")]
        public async Task<IActionResult> Delete(string code)
        {
            try
            {
                await _business.DeleteAsync(code);
                return Ok();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}