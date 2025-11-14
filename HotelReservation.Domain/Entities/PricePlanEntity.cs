using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class PricePlanEntity : BaseEntity
    {
        public string? Name { get; set; }
        public virtual ICollection<HotelRoomEntity> HotelRooms { get; set; }
        public virtual ICollection<DailyPriceEntity> DailyPrices { get; set; }
    }
}
