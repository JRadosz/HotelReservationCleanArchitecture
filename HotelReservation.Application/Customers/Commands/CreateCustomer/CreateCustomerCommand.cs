using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;

namespace HotelReservation.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerCommand : ICommand<ErrorOr<CustomerDto>>
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
    }
}
