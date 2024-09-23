using Employee.Infrastructure.Comman;
using Empolyee.Application.Contracts.Interfaces; 

namespace Employee.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly ApplicationDbContext dbcontext;

        public IEmployeeRepository EmployeeRepository { get; private set; }

        public UnitOfWork(ApplicationDbContext dbcontext)
        {
            this.dbcontext = dbcontext;
            EmployeeRepository = new EmployeeRepository(dbcontext);
        }
         
        public async Task<int> SaveAsync()
        {
            return await dbcontext.SaveChangesAsync(); 
        }
    }
}
