using Clean.Application.Contracts.Persistence;
using Clean.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Clean.Persistence.Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly CleanDbContext _context;

        public GenericRepository(CleanDbContext context)
        {
            _context = context;
        }


        public async Task<TEntity> CreateAsync(TEntity entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task DeleteAsync(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<bool> Exist(int id)
        {
            var entity = await GetEntity(id);
            return entity != null;
        }

        public async Task<IReadOnlyList<TEntity>> GetAllEntities()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public async Task<TEntity> GetEntity(int id)
        {
            return await _context.Set<TEntity>().FindAsync(id);
        }

        public async Task UpdateEntityAsync(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }
    }
}
