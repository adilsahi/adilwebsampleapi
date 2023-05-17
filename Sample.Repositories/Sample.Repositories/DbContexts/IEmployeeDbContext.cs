using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.Repositories.DbContexts
{
    public interface IEmployeeDbContext
    {
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
        int SaveChanges();
        ValueTask DisposeAsync();
        public DbSet<EmployeeEntity> Employees
        {
            get;
            set;
        }
    }
}
