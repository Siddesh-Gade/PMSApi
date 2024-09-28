using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMSWebApi.Data;
using PMSWebApi.Models;

namespace PMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KPIsController : ControllerBase
    {
        private readonly PMSWebApiContext _context;

        public KPIsController(PMSWebApiContext context)
        {
            _context = context;
        }

        // GET: api/KPIs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KPIs>>> GetkPs()
        {
            return await _context.kPs.ToListAsync();
        }

        // GET: api/KPIs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KPIs>> GetKPIs(int id)
        {
            var kPIs = await _context.kPs.FindAsync(id);

            if (kPIs == null)
            {
                return NotFound();
            }

            return kPIs;
        }

        // PUT: api/KPIs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKPIs(int id, KPIs kPIs)
        {
            if (id != kPIs.Id)
            {
                return BadRequest();
            }

            _context.Entry(kPIs).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KPIsExists(id))
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

        // POST: api/KPIs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KPIs>> PostKPIs(KPIs kPIs)
        {
            _context.kPs.Add(kPIs);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKPIs", new { id = kPIs.Id }, kPIs);
        }

        // DELETE: api/KPIs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKPIs(int id)
        {
            var kPIs = await _context.kPs.FindAsync(id);
            if (kPIs == null)
            {
                return NotFound();
            }

            _context.kPs.Remove(kPIs);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KPIsExists(int id)
        {
            return _context.kPs.Any(e => e.Id == id);
        }
    }
}
