using Sample.Repositories.DbContexts;

namespace Sample.Repositories
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> 
        where TEntity :class
    {
        internal IEmployeeDbContext _dbContext;
        public BaseRepository(IEmployeeDbContext dbContext)
        {
            _dbContext = dbContext ?? throw new ArgumentNullException(nameof(dbContext));
        }

        public abstract Task<int?> CreateAsync(TEntity obj);
        public abstract Task<bool> UpdateAsync(TEntity obj);
        public abstract Task<bool> DeleteAsync(int id);
        public abstract Task<TEntity> GetAsync(int id);
        public abstract Task<IEnumerable<TEntity>> GetAsync();
    }
}
