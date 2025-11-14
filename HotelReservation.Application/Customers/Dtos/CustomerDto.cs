namespace HotelReservation.Application.Customers.Dtos
{
    public class CustomerDto
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
