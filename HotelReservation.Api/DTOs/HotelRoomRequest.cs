namespace HotelReservation.Api.DTOs
{
    public class HotelRoomRequest
    {
        public string? Name { get; set; }
        public int RoomNumber { get; set; }
        public int GuestCapacity { get; set; }
        public float Area { get; set; }
    }
}
