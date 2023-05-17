using Sample.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public interface IEmployeeRepository:IBaseRepository<EmployeeEntity>
    {
        Task<IEnumerable<EmployeeEntity>> GetAllByFilterAsync(string firstName,string lastName, string gender);
    }
}
