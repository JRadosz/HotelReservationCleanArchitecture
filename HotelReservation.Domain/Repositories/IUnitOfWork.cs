using HotelReservation.Domain.Entities;

namespace HotelReservation.Domain.Repositories
{
    public interface IUnitOfWork : IDisposable
    {
        IGenericRepository<CustomerEntity> Customers { get; }
        IGenericRepository<HotelRoomEntity> HotelRooms { get; }
        IGenericRepository<ReservationEntity> Reservations { get; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default);
    }
}
