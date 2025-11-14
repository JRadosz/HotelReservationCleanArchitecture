using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;

namespace HotelReservation.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQuery : IQuery<ErrorOr<IEnumerable<CustomerDto>>>
    { }
}
