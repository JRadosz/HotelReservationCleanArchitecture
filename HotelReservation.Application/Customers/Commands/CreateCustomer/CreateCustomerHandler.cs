using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.Customers.Commands.CreateCustomer
{
    public class CreateCustomerHandler
        : ICommandHandler<CreateCustomerCommand, ErrorOr<CustomerDto>>
    {
        ISimpleRepository<CustomerEntity> _repository;
        IMapper _mapper;

        public CreateCustomerHandler(IMapper mapper, ISimpleRepository<CustomerEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ErrorOr<CustomerDto>> Handle(
            CreateCustomerCommand command,
            CancellationToken cancellationToken
        )
        {
            var customer = new CustomerEntity()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            var response = await _repository.AddAsync(customer);

            var result = _mapper.Map<CustomerDto>(response);

            return result;
        }
    }
}
