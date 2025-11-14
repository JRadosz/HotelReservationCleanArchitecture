using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class DailyPriceEntity : BaseEntity
    {
        public DateOnly DateTime { get; set; }
        public float Price { get; set; }
        public required HotelRoomEntity HotelRoom { get; set; }
        public Guid PricePlanId { get; set; }
        public virtual PricePlanEntity PricePlan { get; set; }
    }
}
