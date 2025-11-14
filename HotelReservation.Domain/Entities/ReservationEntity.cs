using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class ReservationEntity : BaseEntity
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public float? Price { get; set; }
        public virtual ICollection<CustomerReservation> CustomerReservations { get; set; } = [];
        public virtual ICollection<HotelRoomReservation> HotelRoomReservations { get; set; } = [];
    }
}
