using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Lab3BusDatabase.Infrastructure;
using Lab3BusDatabase.Infrastructure.Models;

namespace BusManagement.REST.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BusController : ControllerBase
    {
        private readonly BusDbContext _context;

        public BusController(BusDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<BusModel>>> GetBuses()
        {
            return await _context.Buses.Include(b => b.Driver).ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<BusModel>> GetBus(Guid id)
        {
            var bus = await _context.Buses.Include(b => b.Driver).FirstOrDefaultAsync(b => b.Id == id);
            if (bus == null)
                return NotFound();
            return bus;
        }

        [HttpPost]
        public async Task<ActionResult<BusModel>> CreateBus(BusModel bus)
        {
            _context.Buses.Add(bus);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetBus), new { id = bus.Id }, bus);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBus(Guid id, BusModel updatedBus)
        {
            if (id != updatedBus.Id)
                return BadRequest();

            _context.Entry(updatedBus).State = EntityState.Modified;
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteBus(Guid id)
        {
            var bus = await _context.Buses.FindAsync(id);
            if (bus == null)
                return NotFound();

            _context.Buses.Remove(bus);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
