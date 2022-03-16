using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconReactAPI.Data;
using LexiconReactAPI.Models.Entities;

namespace LexiconReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CityController : ControllerBase
    {
        private readonly SqlContext _context;

        public CityController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/City
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CityEntity>>> GetCities()
        {
            return await _context.Cities.ToListAsync();
        }

        // GET: api/City/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CityEntity>> GetCityEntity(int id)
        {
            var cityEntity = await _context.Cities.FindAsync(id);

            if (cityEntity == null)
            {
                return NotFound();
            }

            return cityEntity;
        }

        // PUT: api/City/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCityEntity(int id, CityEntity cityEntity)
        {
            if (id != cityEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(cityEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CityEntityExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        // POST: api/City
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CityEntity>> PostCityEntity(CityEntity cityEntity)
        {
            _context.Cities.Add(cityEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCityEntity", new { id = cityEntity.Id }, cityEntity);
        }

        // DELETE: api/City/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCityEntity(int id)
        {
            var cityEntity = await _context.Cities.FindAsync(id);
            if (cityEntity == null)
            {
                return NotFound();
            }

            _context.Cities.Remove(cityEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CityEntityExists(int id)
        {
            return _context.Cities.Any(e => e.Id == id);
        }
    }
}
