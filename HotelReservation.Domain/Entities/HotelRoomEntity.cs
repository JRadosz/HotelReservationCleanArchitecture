using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class HotelRoomEntity : BaseEntity
    {
        public int RoomNumber { get; set; }
        public string? Name { get; set; }
        public int GuestCapacity { get; set; }
        public float Area { get; set; }
        public virtual ICollection<HotelRoomReservation> HotelRoomReservations { get; set; } = [];
        public Guid? PricePlanId { get; set; }
        public virtual PricePlanEntity? PricePlanEntity { get; set; }
    }
}
