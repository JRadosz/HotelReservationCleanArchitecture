using AutoMapper;
using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.Customers.Queries.GetCustomer
{
    public class GetCustomerQueryHandler : IQueryHandler<GetCustomerQuery, ErrorOr<CustomerDto>>
    {
        ISimpleRepository<CustomerEntity> _repository;
        IMapper _mapper;

        public GetCustomerQueryHandler(ISimpleRepository<CustomerEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CustomerDto>> Handle(GetCustomerQuery query, CancellationToken cancellationToken)
        {
            var customer = await _repository.GetByIdAsync(query.CustomerId);

            if (customer?.Id != query.CustomerId)
            {
                return Error.NotFound(description: "Customer not found");
            }

            var result = _mapper.Map<CustomerDto>(customer);

            return result;
        }
    }
}
