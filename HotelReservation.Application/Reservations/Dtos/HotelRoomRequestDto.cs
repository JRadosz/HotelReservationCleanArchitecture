namespace HotelReservation.Application.Reservations.Dtos
{
    public class HotelRoomRequestDto
    {
        public Guid Id { get; set; }
        public int RoomNumber { get; set; }
        public string? Name { get; set; }
        public int GuestCapacity { get; set; }
        public float Area { get; set; }
    }
}
