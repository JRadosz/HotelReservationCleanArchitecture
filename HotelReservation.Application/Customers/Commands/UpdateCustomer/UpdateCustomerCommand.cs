using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class UpdateCustomerCommand : ICommand<ErrorOr<CustomerDto>>
    {
        public Guid Id { get; set; }
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
