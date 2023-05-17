using Sample.Domains.Models;

namespace Sample.Services
{
    public interface IEmployeeService
    {
        Task<int?> CreateAsync(EmployeeModel employeeModel);
        Task<IEnumerable<EmployeeModel>> GetAllByFilterAsync(EmployeeFilterModel employeeFilterModel);
    }
}
