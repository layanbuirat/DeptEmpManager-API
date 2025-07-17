using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Department.Models;
using Department.DTOs;

namespace Department.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmployeesController : ControllerBase
    {
        private readonly AppDbContext _context;
        public EmployeesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<EmployeeDTO>>> GetAll()
        {
            var list = await _context.Employees
                .Select(e => new EmployeeDTO
                {
                    Id = e.Id,
                    FullName = e.FullName,
                    JobTitle = e.JobTitle,
                    DepartmentId = e.DepartmentId
                })
                .ToListAsync();

            return Ok(list);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<EmployeeDTO>> GetById(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            var dto = new EmployeeDTO
            {
                Id = emp.Id,
                FullName = emp.FullName,
                JobTitle = emp.JobTitle,
                DepartmentId = emp.DepartmentId
            };

            return Ok(dto);
        }

        [HttpPost]
        public async Task<ActionResult> Create([FromBody] EmployeeDTO dto)
        {
            var emp = new Employee
            {
                FullName = dto.FullName,
                JobTitle = dto.JobTitle,
                DepartmentId = dto.DepartmentId
            };

            _context.Employees.Add(dto);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { id = emp.Id }, dto);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, [FromBody] EmployeeDTO dto)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            emp.FullName = dto.FullName;
            emp.JobTitle = dto.JobTitle;
            emp.DepartmentId = dto.DepartmentId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            var emp = await _context.Employees.FindAsync(id);
            if (emp == null) return NotFound();

            _context.Employees.Remove(emp);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
