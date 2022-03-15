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
    public class PersonLanguageController : ControllerBase
    {
        private readonly SqlContext _context;

        public PersonLanguageController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/PersonLanguage
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonLanguageEntity>>> GetPersonLanguages()
        {
            return await _context.PersonLanguages.ToListAsync();
        }

        // GET: api/PersonLanguage/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonLanguageEntity>> GetPersonLanguageEntity(int id)
        {
            var personLanguageEntity = await _context.PersonLanguages.FindAsync(id);

            if (personLanguageEntity == null)
            {
                return NotFound();
            }

            return personLanguageEntity;
        }

        // PUT: api/PersonLanguage/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonLanguageEntity(int id, PersonLanguageEntity personLanguageEntity)
        {
            if (id != personLanguageEntity.PersonId)
            {
                return BadRequest();
            }

            _context.Entry(personLanguageEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonLanguageEntityExists(id))
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

        // POST: api/PersonLanguage
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonLanguageEntity>> PostPersonLanguageEntity(PersonLanguageEntity personLanguageEntity)
        {
            _context.PersonLanguages.Add(personLanguageEntity);
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateException)
            {
                if (PersonLanguageEntityExists(personLanguageEntity.PersonId))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return CreatedAtAction("GetPersonLanguageEntity", new { id = personLanguageEntity.PersonId }, personLanguageEntity);
        }

        // DELETE: api/PersonLanguage/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonLanguageEntity(int id)
        {
            var personLanguageEntity = await _context.PersonLanguages.FindAsync(id);
            if (personLanguageEntity == null)
            {
                return NotFound();
            }

            _context.PersonLanguages.Remove(personLanguageEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonLanguageEntityExists(int id)
        {
            return _context.PersonLanguages.Any(e => e.PersonId == id);
        }
    }
}
