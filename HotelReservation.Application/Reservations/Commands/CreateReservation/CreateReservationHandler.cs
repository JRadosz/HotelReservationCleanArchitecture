using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Application.Reservations.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationHandler
        : ICommandHandler<CreateReservationCommand, ErrorOr<int>>
    {
        IUnitOfWork _unitOfWork;
        IMapper _mapper;

        public CreateReservationHandler(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }

        public async Task<ErrorOr<int>> Handle(
            CreateReservationCommand command,
            CancellationToken cancellationToken
        )
        {
            try
            {
                var reservation = new ReservationEntity
                {
                    StartDate = command.StartDate,
                    EndDate = command.EndDate,
                    Price = command.Price
                };

                var customersId = command.Customers.Where(c => c.Id is not null).Select(c => c.Id).ToList();

                var existingCustomers = await _unitOfWork.Customers.FindAsync(c => customersId.Contains(c.Id));
                var existingCustomersIds = existingCustomers.Select(c => c.Id).ToList();

                var newCustomers = command.Customers.Where(c => c.Id is null || !existingCustomersIds.Contains((Guid)c.Id)).Select(c => _mapper.Map<CustomerEntity>(c)).ToList();

                newCustomers.ForEach(async c => await _unitOfWork.Customers.AddAsync(c));

                var allCustomers = newCustomers.Concat(existingCustomers).ToList();

                allCustomers.ForEach(c =>
                    reservation.CustomerReservations.Add(new CustomerReservation
                    {
                        Customer = c
                    }));

                await _unitOfWork.Reservations.AddAsync(reservation);
                var result = await _unitOfWork.SaveChangesAsync();

                return result;
            }
            catch(Exception e)
            {
                return Error.Unexpected(description:e.Message, metadata: new() { { "StackTrace", e.StackTrace ?? string.Empty } });
            }
        }
    }
}
