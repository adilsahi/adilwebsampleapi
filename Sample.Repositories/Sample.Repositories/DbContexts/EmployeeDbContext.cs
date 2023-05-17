using Microsoft.EntityFrameworkCore;
using Sample.Domains.Entities;
using Sample.Repositories.DbContexts;

namespace Sample.Repositories.DbContexts
{
    public class EmployeeDbContext: DbContext, IEmployeeDbContext
    {
        public EmployeeDbContext(DbContextOptions options) : base(options) { }

        public DbSet<EmployeeEntity> Employees
        {
            get;
            set;
        }

        public override int SaveChanges()
        {
            return base.SaveChanges();
        }

        public async override ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
        }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return await base.SaveChangesAsync(cancellationToken);
        }
    }
}
