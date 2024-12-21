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
    public class EmployeeVMsController : ControllerBase
    {
        private readonly PMSWebApiContext _context;
        private readonly IMapper _mapper;

        public EmployeeVMsController(PMSWebApiContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        // GET: api/EmployeeVMs
        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeVM>>> GetEmployeeVM()
        {
            var employees = await _context.Employees.ToListAsync();

            // Use AutoMapper to map Employees to EmployeeVM
            var employeeVMs = _mapper.Map<List<EmployeeVM>>(employees);

            return Ok(employeeVMs);
        }

        // GET: api/EmployeeVMs/5
        [HttpGet("id/{employeeId}")]
        public async Task<ActionResult<EmployeeVM>> GetEmployeeVM(int employeeId)
        {
            var employees = await _context.Employees.FindAsync(employeeId);

            if (employees == null)
            {
                return NotFound();
            }
            var employeeVMs = _mapper.Map<EmployeeVM>(employees);
            return Ok(employeeVMs);
        }

        [HttpGet("email/{emailId}")]
        public async Task<ActionResult<EmployeeVM>> GetEmployeeLoginEmail(string emailId)
        {
            var employees = await _context.Employees.FirstAsync(x => x.LoginId == emailId);
            if(employees == null)
            {
                return NotFound();
            }
            var employeesVM = _mapper.Map<EmployeeVM>(employees);
            return Ok(employeesVM);
        }

        // PUT: api/EmployeeVMs/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<IActionResult> PutEmployeeVM(int id, EmployeeVM employeeVM)
        {
            if (id != employeeVM.EmployeeId)
            {
                return BadRequest();
            }

            // Fetch the existing employee from the database
            var employeeEntity = await _context.Employees.FindAsync(id);

            if (employeeEntity == null)
            {
                return NotFound();
            }

            // Map the incoming EmployeeVM to the existing employee entity
            _mapper.Map(employeeVM, employeeEntity);

            // Mark the entity as modified
            _context.Entry(employeeEntity).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EmployeeVMExists(id))
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

        // POST: api/EmployeeVMs
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<EmployeeVM>> PostEmployeeVM(EmployeeVM employeeVM)
        {
            var employee = _mapper.Map<Employees>(employeeVM);
            _context.Employees.Add(employee);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetEmployeeVM), new { id = employee.EmployeeId }, employeeVM);
        }

        // DELETE: api/EmployeeVMs/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteEmployeeVM(int id)
        {
            var employees = await _context.Employees.FindAsync(id);
            if (employees == null)
            {
                return NotFound();
            }

            _context.Employees.Remove(employees);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool EmployeeVMExists(int id)
        {
            return _context.Employees.Any(e => e.EmployeeId == id);
        }
    }
}
