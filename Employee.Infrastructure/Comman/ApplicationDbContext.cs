

using Employee.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Comman
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<EmployeeModel> Employee { get; set; }
    }
}
