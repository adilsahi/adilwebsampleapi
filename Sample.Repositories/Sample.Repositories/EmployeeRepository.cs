using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.Repositories.DbContexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories
{
    public class EmployeeRepository : BaseRepository<EmployeeEntity>, IEmployeeRepository
    {
        public EmployeeRepository(EmployeeDbContext dbContext) : base(dbContext)
        {

        }

        public async override Task<int?> CreateAsync(EmployeeEntity employee)
        {
            try
            {
                if (employee != null)
                {
                    await _dbContext.Employees.AddAsync(employee);
                    await _dbContext.SaveChangesAsync();
                    return employee.EmployeeId;
                }
                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async override Task<bool> UpdateAsync(EmployeeEntity employee)
        {
            try
            {
                if (employee != null && employee.EmployeeId > 0)
                {
                    var storedEmployeeEntity = await _dbContext.Employees.FindAsync(employee.EmployeeId);
                    if (storedEmployeeEntity != null)
                    {

                        storedEmployeeEntity.Age = employee.Age;
                        storedEmployeeEntity.FirstName = employee.FirstName;
                        storedEmployeeEntity.LastName = employee.LastName;
                        storedEmployeeEntity.Gender = employee.Gender;

                        await _dbContext.SaveChangesAsync();

                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async override Task<bool> DeleteAsync(int id)
        {
            try
            {
                if (id > 0)
                {
                    var storedEmployeeEntity = await _dbContext.Employees.FindAsync(id);
                    if (storedEmployeeEntity != null)
                    {
                        _dbContext.Employees.Remove(storedEmployeeEntity);
                        await _dbContext.SaveChangesAsync();
                        return true;
                    }
                }
                return false;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async override Task<EmployeeEntity> GetAsync(int id)
        {
            try
            {
                if (id > 0)
                    return await _dbContext.Employees.FindAsync(id);

                return null;
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async override Task<IEnumerable<EmployeeEntity>> GetAsync()
        {
            try
            {
                return await _dbContext.Employees.ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
        public async Task<IEnumerable<EmployeeEntity>> GetAllByFilterAsync(string firstName, string lastName, string gender)
        {
            try
            {
                return await _dbContext.Employees.Where(x=> 
                    (string.IsNullOrWhiteSpace(firstName) || x.FirstName.Equals(firstName)) &&
                    (string.IsNullOrWhiteSpace(lastName) || x.LastName.Equals(lastName)) &&
                    (string.IsNullOrWhiteSpace(gender) || x.Gender.Equals(gender))
                ).ToListAsync();
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
