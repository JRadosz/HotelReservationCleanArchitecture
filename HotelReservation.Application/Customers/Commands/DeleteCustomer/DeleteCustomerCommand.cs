using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerCommand : ICommand<ErrorOr<bool>>
    {
        public Guid Id { get; set; }
    }
}
