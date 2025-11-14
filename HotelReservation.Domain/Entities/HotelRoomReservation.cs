using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class HotelRoomReservation
    {
        public Guid HotelRoomId { get; set; }
        public virtual HotelRoomEntity HotelRoom { get; set; } = null!;
        public Guid ReservationId { get; set; }
        public virtual ReservationEntity Reservation { get; set; } = null!;
    }
}
