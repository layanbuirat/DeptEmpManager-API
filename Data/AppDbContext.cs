using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
namespace Department.DTOs
{
    public class AppDbContext : DbContext

    {
        public DbSet<DepartmentDTO> Departments { get; set; }
        public DbSet<EmployeeDTO> Employees { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }
    }

}

