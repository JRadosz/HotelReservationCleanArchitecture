using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class UpdateCustomerHandler : ICommandHandler<UpdateCustomerCommand, ErrorOr<CustomerDto>>
    {
        ISimpleRepository<CustomerEntity> _repository;
        IMapper _mapper;

        public UpdateCustomerHandler(ISimpleRepository<CustomerEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<CustomerDto>> Handle(UpdateCustomerCommand command, CancellationToken cancellationToken)
        {
            var customer = new CustomerEntity()
            {
                FirstName = command.FirstName,
                LastName = command.LastName,
            };

            var foundCustomer = await _repository.GetByIdAsync(command.Id);

            if (foundCustomer is null)
                return Error.NotFound(description: $"Customer with Id {command.Id} was not found.");

            _mapper.Map(customer, foundCustomer);

            var response = await _repository.UpdateAsync(foundCustomer);
            
            var result = _mapper.Map<CustomerDto>(response);

            return result;
        }
    }
}
