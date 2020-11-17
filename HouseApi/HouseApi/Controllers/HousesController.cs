using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseApi.Models;

namespace HouseApi.Controllers
{
    [Route("api/Houses")]
    [ApiController]
    public class HousesController : ControllerBase
    {
        private readonly HouseApiDbContext _context;

        public HousesController(HouseApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Houses
        [HttpGet]
        public async Task<ActionResult<IEnumerable<House>>> GetHouses()
        {
            return await _context.Houses.ToListAsync();
        }

        // GET: api/Houses/5
        [HttpGet("{id}")]
        public async Task<ActionResult<House>> GetHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);

            if (house == null)
            {
                return NotFound("No such house exists!");
            }

            return house;
        }

        // PUT: api/Houses/5
        [HttpPut("Edit/{id}")]
        public async Task<IActionResult> PutHouse(int id, House house)
        {
            if (id != house.Id)
            {
                return BadRequest("You can only update a house with the same ID");
            }

            try
            {
                if (IsSameHouse(house))
                {
                    return BadRequest("House with the same properties already exist");
                }
                _context.Entry(house).State = EntityState.Modified;
                await _context.SaveChangesAsync();

            }
            catch (DbUpdateConcurrencyException)
            {
                if (!HouseExists(id))
                {
                    return NotFound($"House with such ID {id} does not exist");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"House with id: {id} is updated");
        }

        // POST: api/Houses
        [HttpPost]
        public async Task<ActionResult<House>> PostHouse(House house)
        {
            if (!IsSameHouse(house))
            {
                _context.Houses.Add(house);
                await _context.SaveChangesAsync();
                return CreatedAtAction(nameof(GetHouse), new { id = house.Id }, house);
            }
            return BadRequest("House with the same properties already exist");

        }

        // DELETE: api/Houses/Delete/5
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> DeleteHouse(int id)
        {
            var house = await _context.Houses.FindAsync(id);
            if (house == null)
            {
                return NotFound($"House with ID {id} is not found");
            }

            _context.Houses.Remove(house);
            await _context.SaveChangesAsync();

            return Ok($"You have successfully deleted house with ID: {id}");
        }

        private bool HouseExists(int id)
        {
            return _context.Houses.Any(e => e.Id == id);
        }

        private bool IsSameHouse(House house)
        {
            return _context.Houses.Any
            (e =>
                    e.Number == house.Number &&
                    e.Street == house.Street &&
                    e.ZipCode == house.ZipCode &&
                    e.Country == house.Country);
        }
    }
}
