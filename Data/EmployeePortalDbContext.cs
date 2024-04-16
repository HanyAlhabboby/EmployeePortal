using EmployeePortal.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace EmployeePortal.Data
{
    public class EmployeePortalDbContext : IdentityDbContext
    {
        public EmployeePortalDbContext(DbContextOptions<EmployeePortalDbContext> options) : base(options)
        {
           

        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<TimeOffWork> timeOffWorks { get; set; }

    }
}
