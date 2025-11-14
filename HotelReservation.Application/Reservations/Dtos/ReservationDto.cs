using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.Reservations.Dtos
{
    public class ReservationDto
    {
        public Guid Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Price { get; set; }
        public IEnumerable<CustomerRequestDto> Customers { get; set; } = [];
        public IEnumerable<HotelRoomRequestDto> HotelRooms { get; set; } = [];
    }
}
