using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PMSWebApi.Data;
using PMSWebApi.Models;
using PMSWebApi.ViewModels;

namespace PMSWebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoundsVMsController : ControllerBase
    {
        private readonly PMSWebApiContext _context;
        private readonly IMapper _mapper;

        public RoundsVMsController(PMSWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/RoundsVMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<RoundsVM>>> GetRoundsVM()
        {
            var rounds = await _context.Rounds.ToListAsync();
            var roundsVM = _mapper.Map<List<RoundsVM>>(rounds);
            return Ok(roundsVM);
        }

        // GET: api/RoundsVMs/5
        [HttpGet("{id}")]
        public async Task<ActionResult<RoundsVM>> GetRoundsVM(int id)
        {
            var rounds = await _context.Rounds.FindAsync(id);

            if (rounds == null)
            {
                return NotFound();
            }
            var roundsVM = _mapper.Map<RoundsVM>(rounds);
            return roundsVM;
        }

        // PUT: api/RoundsVMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutRoundsVM(int id, RoundsVM roundsVM)
        {
            if (id != roundsVM.Id)
            {
                return BadRequest();
            }

            _context.Entry(roundsVM).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoundsVMExists(id))
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

        // POST: api/RoundsVMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<RoundsVM>> PostRoundsVM(RoundsVM roundsVM)
        {
            var rounds = _mapper.Map<Rounds>(roundsVM);
            _context.Rounds.Add(rounds);
            await _context.SaveChangesAsync();

            return CreatedAtAction("GetRoundsVM", new { id = roundsVM.Id }, roundsVM);
        }

        // DELETE: api/RoundsVMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoundsVM(int id)
        {
            var roundsVM = await _context.Rounds.FindAsync(id);
            if (roundsVM == null)
            {
                return NotFound();
            }

            _context.Rounds.Remove(roundsVM);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool RoundsVMExists(int id)
        {
            return _context.Rounds.Any(e => e.Id == id);
        }
    }
}
