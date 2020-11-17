using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseApi.Models;

namespace HouseApi.Controllers
{
    [Route("api/Flats")]
    [ApiController]
    public class FlatsController : ControllerBase
    {
        private readonly HouseApiDbContext _context;

        public FlatsController(HouseApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Flats
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Flat>>> GetFlats()
        {
            return await _context.Flats.ToListAsync();
        }

        // GET: api/Flats/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Flat>> GetFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);

            if (flat == null)
            {
                return NotFound($"Flat with ID: {id} is not found");
            }

            return flat;
        }

        // PUT: api/Flats/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutFlat(int id, Flat flat)
        {
            if (id != flat.Id)
            {
                return BadRequest("You can only update a Flat with the same ID");
            }

            try
            {
                if (IsTheSameFlat(flat))
                {
                    return BadRequest("Flat with the same properties already exist");
                }
                _context.Entry(flat).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!FlatExists(id))
                {
                    return NotFound("Flat with ID {id} does not exist");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Flat with ID {id} is updated");
        }

        // POST: api/Flats
        [HttpPost]
        public async Task<ActionResult<Flat>> PostFlat(Flat flat)
        {
            if (!IsTheSameFlat(flat))
            {
                await _context.Flats.AddAsync(flat);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetFlat", new { id = flat.Id }, flat);
            }

            return BadRequest("Flat with the same properties already exist");
        }

        // DELETE: api/Flats/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlat(int id)
        {
            var flat = await _context.Flats.FindAsync(id);
            if (flat == null)
            {
                return NotFound($"Flat with ID: {id} is not found");
            }

            _context.Flats.Remove(flat);
            await _context.SaveChangesAsync();

            return Ok($"You have successfully deleted flat with ID: {id}");
        }

        private bool FlatExists(int id)
        {
            return _context.Flats.Any(e => e.Id == id);
        }

        private bool IsTheSameFlat(Flat flat)
        {
            return _context.Flats.Any(
                f =>
                    f.Floor == flat.Floor &&
                    f.HouseId == flat.HouseId &&
                    f.Number == flat.Number);
        }
    }
}
