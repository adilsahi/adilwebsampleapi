using Sample.Domains.Entities;
using Sample.Domains.Models;
using Sample.Domains.TranslationExtensions;
using Sample.Repositories;

namespace Sample.Services
{
    public class EmployeeService:IEmployeeService
    {
        private readonly IEmployeeRepository _employeeRepository;
        public EmployeeService(IEmployeeRepository employeeRepository)
        {
            _employeeRepository = employeeRepository ?? throw new ArgumentNullException(nameof(employeeRepository));
        }

        public async Task<int?> CreateAsync(EmployeeModel employeeModel)
        {
            if(employeeModel != null)
            {
                EmployeeEntity employeeEntity = employeeModel.Translate();

                if (employeeEntity.EmployeeId > 0)
                {
                    var result = await _employeeRepository.UpdateAsync(employeeEntity);
                    if (result)
                        return employeeEntity.EmployeeId;
                }
                else
                {
                    return await _employeeRepository.CreateAsync(employeeEntity);
                }
            }

            return null;
        }

        public async Task<IEnumerable<EmployeeModel>> GetAllByFilterAsync(EmployeeFilterModel employeeFilterModel)
        {
            var result = await _employeeRepository.GetAllByFilterAsync(employeeFilterModel?.FirstName,employeeFilterModel?.LastName,employeeFilterModel?.Gender);

            if(result.Any())
            {
                return result.Select(x => x.Translate());
            }

            return null;
        }
    }
}
