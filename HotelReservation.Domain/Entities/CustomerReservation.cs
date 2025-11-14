using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class CustomerReservation
    {
        public Guid CustomerId { get; set; }
        public virtual CustomerEntity Customer { get; set; } = null!;
        public Guid ReservationId { get; set; }
        public virtual ReservationEntity Reservation { get; set; } = null!;
    }
}
