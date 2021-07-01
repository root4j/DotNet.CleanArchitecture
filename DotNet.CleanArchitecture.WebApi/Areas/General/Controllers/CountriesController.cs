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
    public class CountriesController : ControllerBase
    {
        private readonly ICountryBusiness _business;

        public CountriesController(ICountryBusiness business)
        {
            _business = business;
        }

        // GET: General/api/Countries
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Country>>> Get()
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

        // GET: General/api/Countries/COL
        [HttpGet("{code}")]
        public async Task<ActionResult<Country>> Get(string code)
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

        // PUT: General/api/Countries/COL
        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] Country entity)
        {
            try
            {
                if (code != entity.CountryCode)
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

        // POST: General/api/Countries
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] Country entity)
        {
            try
            {
                await _business.CreateAsync(entity.CountryCode, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: General/api/Countries/COL
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