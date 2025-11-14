namespace HotelReservation.Application.Reservations.Dtos
{
    public class CustomerRequestDto
    {
        public Guid? Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
