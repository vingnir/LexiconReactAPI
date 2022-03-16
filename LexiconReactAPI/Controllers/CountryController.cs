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
    public class CountryController : ControllerBase
    {
        private readonly SqlContext _context;

        public CountryController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Country
        [HttpGet]
        public async Task<ActionResult<IEnumerable<CountryEntity>>> GetCountries()
        {
            return await _context.Countries.ToListAsync();
        }

        // GET: api/Country/5
        [HttpGet("{id}")]
        public async Task<ActionResult<CountryEntity>> GetCountryEntity(int id)
        {
            var countryEntity = await _context.Countries.FindAsync(id);

            if (countryEntity == null)
            {
                return NotFound();
            }

            return countryEntity;
        }

        // PUT: api/Country/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCountryEntity(int id, CountryEntity countryEntity)
        {
            if (id != countryEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(countryEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CountryEntityExists(id))
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

        // POST: api/Country
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<CountryEntity>> PostCountryEntity(CountryEntity countryEntity)
        {
            _context.Countries.Add(countryEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCountryEntity", new { id = countryEntity.Id }, countryEntity);
        }

        // DELETE: api/Country/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCountryEntity(int id)
        {
            var countryEntity = await _context.Countries.FindAsync(id);
            if (countryEntity == null)
            {
                return NotFound();
            }

            _context.Countries.Remove(countryEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CountryEntityExists(int id)
        {
            return _context.Countries.Any(e => e.Id == id);
        }
    }
}
