using HotelReservation.Domain.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HotelReservation.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly AppDbContext _dbContext;

        public GenericRepository(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        // Get all entities
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbContext.Set<T>().AsNoTracking().ToListAsync();
        }

        // Get entities by filter                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        
        public async Task<IEnumerable<T>> FindAsync(Expression<Func<T, bool>> predicate)
        {
            if (predicate == null)
                return await GetAllAsync();

            return await _dbContext.Set<T>().Where(predicate).ToListAsync();
        }

        // Get by primary key (assumes Guid)
        public async Task<T?> GetByIdAsync(Guid id)
        {
            return await _dbContext.Set<T>().FindAsync(id);
        }

        // Add a new entity
        public virtual async Task<T> AddAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _dbContext.AddAsync(entity);

            return entity;
        }

        // Update an existing entity
        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var result = _dbContext.Set<T>().Update(entity);

            return result.Entity;
        }

        // Delete an entity
        public virtual async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return false;

            var result = _dbContext.Set<T>().Remove(entity);

            return true;
        }
    }
}
