using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Department.Models;
using Department.DTOs;
namespace Department.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentsController : ControllerBase

    {

        private readonly AppDbContext _context;
            public DepartmentsController(AppDbContext context)
            {
                _context = context;
            }

            [HttpGet]
            public async Task<ActionResult<IEnumerable<DepartmentDTO>>> GetAll()
            {
                var list = await _context.Departments
                    .Select(d => new DepartmentDTO { Id = d.Id, Name = d.Name })
                    .ToListAsync();

                return Ok(list);
            }

            [HttpGet("{id}")]
            public async Task<ActionResult<DepartmentDTO>> GetById(int id)
            {
                var dept = await _context.Departments.FindAsync(id);
                if (dept == null) return NotFound();

                var dto = new DepartmentDTO { Id = dept.Id, Name = dept.Name };
                return Ok(dto);
            }

            [HttpPost]
            public async Task<ActionResult> Create([FromBody] DepartmentDTO dto)
            {
                var dept = new DepartmentDTO { Name = dto.Name };
                _context.Departments.Add(dept);
                await _context.SaveChangesAsync();

                return CreatedAtAction(nameof(GetById), new { id = dept.Id }, dto);
            }

            [HttpPut("{id}")]
            public async Task<ActionResult> Update(int id, [FromBody] DepartmentDTO dto)
            {
                var dept = await _context.Departments.FindAsync(id);
                if (dept == null) return NotFound();

                dept.Name = dto.Name;
                await _context.SaveChangesAsync();

                return NoContent();
            }

            [HttpDelete("{id}")]
            public async Task<ActionResult> Delete(int id)
            {
                var dept = await _context.Departments.FindAsync(id);
                if (dept == null) return NotFound();

                _context.Departments.Remove(dept);
                await _context.SaveChangesAsync();

                return NoContent();
            }
        }

    }
