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
    public class LanguageController : ControllerBase
    {
        private readonly SqlContext _context;

        public LanguageController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Language
        [HttpGet]
        public async Task<ActionResult<IEnumerable<LanguageEntity>>> GetLanguages()
        {
            return await _context.Languages.ToListAsync();
        }

        // GET: api/Language/5
        [HttpGet("{id}")]
        public async Task<ActionResult<LanguageEntity>> GetLanguageEntity(int id)
        {
            var languageEntity = await _context.Languages.FindAsync(id);

            if (languageEntity == null)
            {
                return NotFound();
            }

            return languageEntity;
        }

        // PUT: api/Language/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutLanguageEntity(int id, LanguageEntity languageEntity)
        {
            if (id != languageEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(languageEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!LanguageEntityExists(id))
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

        // POST: api/Language
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<LanguageEntity>> PostLanguageEntity(LanguageEntity languageEntity)
        {
            _context.Languages.Add(languageEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetLanguageEntity", new { id = languageEntity.Id }, languageEntity);
        }

        // DELETE: api/Language/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteLanguageEntity(int id)
        {
            var languageEntity = await _context.Languages.FindAsync(id);
            if (languageEntity == null)
            {
                return NotFound();
            }

            _context.Languages.Remove(languageEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool LanguageEntityExists(int id)
        {
            return _context.Languages.Any(e => e.Id == id);
        }
    }
}
