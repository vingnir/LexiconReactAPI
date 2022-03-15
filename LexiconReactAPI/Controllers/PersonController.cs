using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using LexiconReactAPI.Data;
using LexiconReactAPI.Models.Entities;
using LexiconReactAPI.Models;

namespace LexiconReactAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonController : ControllerBase
    {
        private readonly SqlContext _context;

        public PersonController(SqlContext context)
        {
            _context = context;
        }

        // GET: api/Person
        [HttpGet]
        public async Task<ActionResult<IEnumerable<PersonModel>>> GetPeople()
        {
            var people = new List<PersonModel>();
            foreach (var p in await _context.People.Include(x => x.City).ToListAsync())
                people.Add(new PersonModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    CityName = p.City.CityName
                });
                return people;
        }

        // GET: api/Person/5
        [HttpGet("{id}")]
        public async Task<ActionResult<PersonModel>> GetPersonEntity(int id)
        {
            var personEntity = await _context.People
                .Include(x => x.City)
                .Include(x => x.Country)
                .FirstOrDefaultAsync(x => x.Id == id);

            if (personEntity == null)
            {
                return NotFound();
            }

            return new PersonModel
            {
                Id = personEntity.Id,
                Name = personEntity.Name,    
                PhoneNumber= personEntity.PhoneNumber,  
                CityName= personEntity.City.CityName, 
                CountryName= personEntity.Country.CountryName
            };
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEntity(int id, PersonEntity personEntity)
        {
            if (id != personEntity.Id)
            {
                return BadRequest();
            }

            _context.Entry(personEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PersonEntityExists(id))
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

        // POST: api/Person
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<PersonModel>> PostPersonEntity(PersonCreateModel model)
        {
            var personEntity = new PersonEntity()
            {
                Name = model.Name,
                //CurrentCityId = model.CurrentCityId,
                PhoneNumber = model.PhoneNumber
            };
            _context.People.Add(personEntity);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetPersonEntity", new { id = personEntity.Id }, new PersonModel { Id = personEntity.Id, Name = personEntity.Name, PhoneNumber = personEntity.PhoneNumber});
        }

        // DELETE: api/Person/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeletePersonEntity(int id)
        {
            var personEntity = await _context.People.FindAsync(id);
            if (personEntity == null)
            {
                return NotFound();
            }

            _context.People.Remove(personEntity);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool PersonEntityExists(int id)
        {
            return _context.People.Any(e => e.Id == id);
        }
    }
}
