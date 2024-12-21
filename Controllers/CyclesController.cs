using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMSWebApi.Data;
using PMSWebApi.Models;

namespace PMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CyclesController : ControllerBase
    {
        private readonly PMSWebApiContext _context;

        public CyclesController(PMSWebApiContext context)
        {
            _context = context;
        }

        // GET: api/Cycles
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Cycle>>> GetCycle()
        {
            return await _context.Cycle.ToListAsync();
        }

        // GET: api/Cycles/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Cycle>> GetCycle(int id)
        {
            var cycle = await _context.Cycle.FindAsync(id);

            if (cycle == null)
            {
                return NotFound();
            }

            return cycle;
        }

        // PUT: api/Cycles/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCycle(int id, Cycle cycle)
        {
            if (id != cycle.CycleId)
            {
                return BadRequest();
            }

            _context.Entry(cycle).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CycleExists(id))
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

        // POST: api/Cycles
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Cycle>> PostCycle(Cycle cycle)
        {
            _context.Cycle.Add(cycle);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetCycle", new { id = cycle.CycleId }, cycle);
        }

        // DELETE: api/Cycles/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCycle(int id)
        {
            var cycle = await _context.Cycle.FindAsync(id);
            if (cycle == null)
            {
                return NotFound();
            }

            _context.Cycle.Remove(cycle);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool CycleExists(int id)
        {
            return _context.Cycle.Any(e => e.CycleId == id);
        }
    }
}
