namespace Clean.Application.Persistence.Contract
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        Task<TEntity> GetEntity(int id);
        Task<TEntity> CreateAsync(TEntity entity);
        Task<IReadOnlyList<TEntity>> GetAllEntities();

        void Delete(TEntity entity);
        void Update(TEntity entity);
    }
}
