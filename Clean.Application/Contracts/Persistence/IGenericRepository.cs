namespace Clean.Application.Contracts.Persistence
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntity(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetAllEntities();
        Task<bool> Exist(int id);
        Task UpdateEntityAsync(TEntity entity);
        Task DeleteAsync(TEntity entity);
    }
}
