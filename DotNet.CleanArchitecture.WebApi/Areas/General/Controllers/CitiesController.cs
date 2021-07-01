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
    public class CitiesController : ControllerBase
    {
        private readonly ICityBusiness _business;

        public CitiesController(ICityBusiness business)
        {
            _business = business;
        }

        // GET: General/api/Cities
        [HttpGet]
        public async Task<ActionResult<IEnumerable<City>>> Get()
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

        // GET: General/api/Cities/COL-05001
        [HttpGet("{code}")]
        public async Task<ActionResult<City>> Get(string code)
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

        // GET: General/api/Cities/State/COL-05
        [HttpGet("State/{stateCode}")]
        public async Task<ActionResult<IEnumerable<City>>> GetByStateCode(string stateCode)
        {
            try
            {
                return await _business.ReadAllAsync(stateCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: General/api/Cities/COL-05001
        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] City entity)
        {
            try
            {
                if (code != entity.CityCode)
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

        // POST: General/api/Cities
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] City entity)
        {
            try
            {
                await _business.CreateAsync(entity.CityCode, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: General/api/Cities/COL-05001
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