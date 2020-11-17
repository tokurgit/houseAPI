using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using HouseApi.Models;

namespace HouseApi.Controllers
{
    [Route("api/Residents")]
    [ApiController]
    public class ResidentsController : ControllerBase
    {
        private readonly HouseApiDbContext _context;

        public ResidentsController(HouseApiDbContext context)
        {
            _context = context;
        }

        // GET: api/Residents
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Resident>>> GetResidents()
        {
            return await _context.Residents.ToListAsync();
        }

        // GET: api/Residents/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Resident>> GetResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);

            if (resident == null)
            {
                return NotFound($"Resident with ID {id} is not found");
            }

            return resident;
        }

        // PUT: api/Residents/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutResident(int id, Resident resident)
        {
            if (id != resident.Id)
            {
                return BadRequest("You can only update a resident with the same ID");
            }

            try
            {
                if (IsTheSameResident(resident))
                {
                    return BadRequest("Resident with the same properties already exist");
                }
                _context.Entry(resident).State = EntityState.Modified;
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ResidentExists(id))
                {
                    return NotFound($"Resident with such id {id} does not exist");
                }
                else
                {
                    throw;
                }
            }

            return Ok($"Resident with ID {id} is updated");
        }

        // POST: api/Residents
        [HttpPost]
        public async Task<ActionResult<Resident>> PostResident(Resident resident)
        {
            if (!IsTheSameResident(resident))
            {
                _context.Residents.Add(resident);
                await _context.SaveChangesAsync();
                return CreatedAtAction("GetResident", new { id = resident.Id }, resident);
            }

            return BadRequest("Resident with the same properties already exist");
        }

        // DELETE: api/Residents/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteResident(int id)
        {
            var resident = await _context.Residents.FindAsync(id);
            if (resident == null)
            {
                return NotFound($"Resident with ID: {id} is not found");
            }

            _context.Residents.Remove(resident);
            await _context.SaveChangesAsync();

            return Ok($"You have successfully deleted resident with ID: {id}");
        }

        private bool ResidentExists(int id)
        {
            return _context.Residents.Any(e => e.Id == id);
        }

        private bool IsTheSameResident(Resident res)
        {
            return _context.Residents.Any
            (r =>
                r.Name == res.Name &&
                r.Surname == res.Surname &&
                r.DateOfBirth == res.DateOfBirth &&
                r.EMail == res.EMail &&
                r.PersonalCode == res.PersonalCode);
        }
    }
}
