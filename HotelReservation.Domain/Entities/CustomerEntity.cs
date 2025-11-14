using HotelReservation.Domain.Common;

namespace HotelReservation.Domain.Entities
{
    public class CustomerEntity : BaseEntity
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public virtual ICollection<CustomerReservation> CustomerReservation { get; set; } = [];
    }
}
