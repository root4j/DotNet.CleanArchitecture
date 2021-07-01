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
    public class ValueListsController : ControllerBase
    {
        private readonly IValueListBusiness _business;

        public ValueListsController(IValueListBusiness business)
        {
            _business = business;
        }

        // GET: General/api/ValueLists
        [HttpGet]
        public async Task<ActionResult<IEnumerable<ValueList>>> Get()
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

        // GET: General/api/ValueLists/COL-05
        [HttpGet("{code}")]
        public async Task<ActionResult<ValueList>> Get(string code)
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

        // GET: General/api/ValueLists/Category/Gen-Sex
        [HttpGet("Category/{categoryCode}")]
        public async Task<ActionResult<IEnumerable<ValueList>>> GetByCategoryCode(string categoryCode)
        {
            try
            {
                return await _business.ReadAllAsync(categoryCode);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // PUT: General/api/ValueLists/COL-05
        [HttpPut("{code}")]
        public async Task<IActionResult> Put(string code, [FromBody] ValueList entity)
        {
            try
            {
                if (code != entity.ValueListCode)
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

        // POST: General/api/ValueLists
        [HttpPost]
        public async Task<ActionResult> Post([FromBody] ValueList entity)
        {
            try
            {
                await _business.CreateAsync(entity.ValueListCode, entity);
                return Ok(entity);
            }
            catch (Exception)
            {
                throw;
            }
        }

        // DELETE: General/api/ValueLists/COL-05
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