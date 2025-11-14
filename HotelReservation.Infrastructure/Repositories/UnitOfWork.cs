using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly AppDbContext _dbContext;

        private IGenericRepository<CustomerEntity> _customers;
        private IGenericRepository<HotelRoomEntity> _hotelRooms;
        private IGenericRepository<ReservationEntity> _reservations;

        public UnitOfWork(AppDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IGenericRepository<CustomerEntity> Customers => _customers ??= new GenericRepository<CustomerEntity>(_dbContext);

        public IGenericRepository<HotelRoomEntity> HotelRooms => _hotelRooms ??= new GenericRepository<HotelRoomEntity>(_dbContext);

        public IGenericRepository<ReservationEntity> Reservations => _reservations ??= new GenericRepository<ReservationEntity>(_dbContext);

        public void Dispose()
        {
            _dbContext.Dispose();
        }

        public Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            return _dbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
