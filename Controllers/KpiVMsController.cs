using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMSWebApi.Data;
using PMSWebApi.Models;
using PMSWebApi.ViewModels;

namespace PMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KpiVMsController : ControllerBase
    {
        private readonly PMSWebApiContext _context;
        private readonly IMapper _mapper;

        public KpiVMsController(PMSWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/KpiVMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<KpiVM>>> GetKpiVM()
        {
            var Kpis =  _context.kPs.ToListAsync();
            var KpisVMs = _mapper.Map<List<KpiVM>>(Kpis);
            return Ok(KpisVMs);
        }

        // GET: api/KpiVMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<KpiVM>> GetKpiVM(int id)
        {
            var Kpis = await _context.kPs.FindAsync(id);

            if (Kpis == null)
            {
                return NotFound();
            }
            var KpisVMs = _mapper.Map<KpiVM>(Kpis);
            return KpisVMs;
        }

        // PUT: api/KpiVMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutKpiVM(int id, KpiVM kpiVM)
        {
            if (id != kpiVM.Id)
            {
                return BadRequest();
            }

            var KpisEntity = await _context.kPs.FindAsync(id);

            if (KpisEntity == null)
            {
                return NotFound();
            }

            _mapper.Map(kpiVM, KpisEntity);

            _context.Entry(KpisEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!KpiVMExists(id))
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

        // POST: api/KpiVMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<KpiVM>> PostKpiVM(KpiVM kpiVM)
        {
            var Kpis = _mapper.Map<KPIs>(kpiVM);
            _context.kPs.Add(Kpis);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetKpiVM", new { id = kpiVM.Id }, kpiVM);
        }

        // DELETE: api/KpiVMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteKpiVM(int id)
        {
            var kpiVM = await _context.kPs.FindAsync(id);
            if (kpiVM == null)
            {
                return NotFound();
            }

            _context.kPs.Remove(kpiVM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool KpiVMExists(int id)
        {
            return _context.kPs.Any(e => e.Id == id);
        }
    }
}
