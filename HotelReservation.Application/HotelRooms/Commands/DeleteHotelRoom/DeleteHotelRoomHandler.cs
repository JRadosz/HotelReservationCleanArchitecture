using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class DeleteHotelRoomHandler : ICommandHandler<DeleteHotelRoomCommand, ErrorOr<bool>>
    {
        ISimpleRepository<HotelRoomEntity> _repository;

        public DeleteHotelRoomHandler(ISimpleRepository<HotelRoomEntity> repository)
        {
            _repository = repository;
        }

        public async Task<ErrorOr<bool>> Handle(DeleteHotelRoomCommand command, CancellationToken cancellationToken)
        {
            var result = await _repository.DeleteAsync(command.Id);

            if (!result)
                return Error.NotFound(description: $"Hotel room with Id {command.Id} was not found.");

            return result;
        }
    }
}
