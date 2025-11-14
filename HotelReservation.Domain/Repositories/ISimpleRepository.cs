using System.Linq.Expressions;

namespace HotelReservation.Domain.Repositories
{
    public interface ISimpleRepository<T> : IGenericRepository<T> where T : class
    {
        Task SaveAsync();
    }
}
