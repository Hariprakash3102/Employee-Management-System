

using Employee.Domain.Models;
using Employee.Infrastructure.Comman;
using Empolyee.Application.Contracts.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Employee.Infrastructure.Repositories
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly ApplicationDbContext dbcontext;

        public EmployeeRepository(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
        }

        public async Task Add(EmployeeModel employee)
        {
            dbcontext.Employee.Add(employee);
            await dbcontext.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var employee = await dbcontext.Employee.FindAsync(id);

            if (employee != null)
            {
                dbcontext.Remove(employee);
                await dbcontext.SaveChangesAsync();
            }


        }

        public async Task<IEnumerable<EmployeeModel>> Get()
        {
           return await dbcontext.Employee.ToListAsync(); 
        }

        public async Task<EmployeeModel> GetByid(Guid id)
        {
            var employee = await dbcontext.Employee.AsNoTracking().FirstOrDefaultAsync(e => e.EmployeeId ==id);
            return employee!;
        }

        public async Task Update(EmployeeModel employee)
        {
            dbcontext.Entry(employee).State = EntityState.Modified;

            await dbcontext.SaveChangesAsync();
        }
    }
}
