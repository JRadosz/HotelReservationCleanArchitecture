using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;

namespace HotelReservation.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQuery : IQuery<ErrorOr<CustomerDto>>
    {   
        public Guid CustomerId { get; set; }
    }
}
