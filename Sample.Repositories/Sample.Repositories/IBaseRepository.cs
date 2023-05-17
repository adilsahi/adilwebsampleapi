namespace Sample.Repositories
{
    public interface IBaseRepository<TEntity>
    {
        Task<int?> CreateAsync(TEntity obj);
        Task<bool> UpdateAsync(TEntity obj);
        Task<bool> DeleteAsync(int id);
        Task<TEntity> GetAsync(int id);
        Task<IEnumerable<TEntity>> GetAsync();
    }
}
