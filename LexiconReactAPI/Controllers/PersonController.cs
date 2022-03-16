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
            foreach (var p in await _context.People
                .Include(x => x.City)
                .Include(x => x.Country)
                .ToListAsync())
                people.Add(new PersonModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    CityName = p.City.CityName, 
                    CountryName = p.Country.CountryName
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
                PhoneNumber = personEntity.PhoneNumber,  
                CityName = personEntity.City.CityName, 
                CountryName = personEntity.Country.CountryName
            };
        }

        // PUT: api/Person/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutPersonEntity(int id, PersonUpdateModel model)
        {
            if (id != model.Id)
            {
                return BadRequest();
            }

            var personEntity = await _context.People.FindAsync(id);
            personEntity.Name = model.Name;
            personEntity.PhoneNumber = model.PhoneNumber;
            personEntity.CityId = model.CurrentCityId;
            personEntity.CountryId = model.CountryId;

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
        public async Task<ActionResult<PersonEntity>> PostPersonEntity(PersonCreateModel model)
        {
            var personEntity = new PersonEntity();

            var cityEntity = await _context.Cities.FirstOrDefaultAsync(c => c.CityName == model.CityName);
            var countryEntity = await _context.Countries.FirstOrDefaultAsync(c => c.CountryName == model.CountryName);
            if (cityEntity == null) 
            {
                cityEntity = new CityEntity { CityName = model.CityName };
                _context.Cities.Add(cityEntity);
                await _context.SaveChangesAsync();
            }
            if (countryEntity == null)
            {
                countryEntity = new CountryEntity { CountryName = model.CountryName };
                _context.Countries.Add(countryEntity);
                await _context.SaveChangesAsync();
            }

            if (countryEntity != null && cityEntity !=null)
            { 
                personEntity = new PersonEntity
            {
                Name = model.Name,
                PhoneNumber = model.PhoneNumber,
                CountryId = countryEntity.Id,
                CityId = cityEntity.Id
            };
                        
            _context.People.Add(personEntity);
            }

            await _context.SaveChangesAsync();

            var p = await _context.People
                .Include(x => x.Country)
                .Include(x => x.City)
                .FirstOrDefaultAsync(x => x.Id == personEntity.Id);



            return CreatedAtAction("GetPersonEntity", new { id = personEntity.Id },
                new PersonModel 
                { Id = p.Id,
                    Name = p.Name,
                    PhoneNumber = p.PhoneNumber,
                    CityName = p.City.CityName,
                    CountryName = p.Country.CountryName,
                });
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
