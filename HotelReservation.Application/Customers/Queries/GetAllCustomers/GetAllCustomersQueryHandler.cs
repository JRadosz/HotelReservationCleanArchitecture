using AutoMapper;
using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.Customers.Queries.GetAllCustomers
{
    public class GetAllCustomersQueryHandler : IQueryHandler<GetAllCustomersQuery, ErrorOr<IEnumerable<CustomerDto>>>
    {
        ISimpleRepository<CustomerEntity> _repository;
        IMapper _mapper;

        public GetAllCustomersQueryHandler(ISimpleRepository<CustomerEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<IEnumerable<CustomerDto>>> Handle(GetAllCustomersQuery query, CancellationToken cancellationToken)
        {
            var customers = await _repository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<CustomerDto>>(customers).ToList();

            return result;
        }
    }
}
