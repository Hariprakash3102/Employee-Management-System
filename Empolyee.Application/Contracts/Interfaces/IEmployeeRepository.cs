using Employee.Domain.Models; 

namespace Empolyee.Application.Contracts.Interfaces
{
    public interface IEmployeeRepository
    {
        Task<IEnumerable<EmployeeModel>> Get();

        Task<EmployeeModel> GetByid(Guid id);

        Task Add(EmployeeModel employee);
        Task Delete(Guid id);

        Task Update(EmployeeModel employee);

    }
}
