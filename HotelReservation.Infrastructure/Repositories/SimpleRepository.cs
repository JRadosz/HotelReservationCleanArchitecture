using HotelReservation.Domain.Repositories;

namespace HotelReservation.Infrastructure.Repositories
{
    public class SimpleRepository<T> : GenericRepository<T>, ISimpleRepository<T> where T : class
    {
        public SimpleRepository(AppDbContext dbContext) : base(dbContext) 
        {
        }        

        // Add a new entity
        public override async Task<T> AddAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            await _dbContext.AddAsync(entity);
            await SaveAsync();

            return entity;
        }

        // Update an existing entity
        public async Task<T> UpdateAsync(T entity)
        {
            if (entity == null) 
                throw new ArgumentNullException(nameof(entity));

            var result = _dbContext.Set<T>().Update(entity);
            await SaveAsync();

            return result.Entity;
        }

        // Delete an entity
        public async Task<bool> DeleteAsync(Guid id)
        {
            var entity = await GetByIdAsync(id);

            if (entity == null)
                return false;

            var result = _dbContext.Set<T>().Remove(entity);
            await SaveAsync();

            return true;
        }

        public async Task SaveAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
