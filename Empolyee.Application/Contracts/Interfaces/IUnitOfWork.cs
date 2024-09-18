

namespace Empolyee.Application.Contracts.Interfaces
{
    public interface IUnitOfWork
    { 
        IEmployeeRepository EmployeeRepository { get; }

        Task<int> SaveAsync();

    }
}
