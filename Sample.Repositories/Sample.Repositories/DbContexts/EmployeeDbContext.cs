using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.Repositories.DbContexts;

namespace Sample.Repositories.DbContexts
{
    public class EmployeeDbContext: DbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EmployeeEntity> Employees
        {
            get;
            set;
        }
    }
}
