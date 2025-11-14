using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.Customers.Commands.DeleteCustomer
{
    public class DeleteCustomerHandler : ICommandHandler<DeleteCustomerCommand, ErrorOr<bool>>
    {
        ISimpleRepository<CustomerEntity> _repository;
        IUnitOfWork _unitOfWork;

        public DeleteCustomerHandler(ISimpleRepository<CustomerEntity> repository, IUnitOfWork unitOfWork)
        {
            _repository = repository;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteCustomerCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(command.Id);
            await _unitOfWork.SaveChangesAsync(cancellationToken);

            if (!result)
                return Error.NotFound(description: $"Command with Id {command.Id} was not found.");

            return result;
        }
    }
}
