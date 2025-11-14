using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class UpdateHotelRoomHandler : ICommandHandler<UpdateHotelRoomCommand, ErrorOr<HotelRoomDto>>
    {
        ISimpleRepository<HotelRoomEntity> _repository;
        IMapper _mapper;

        public UpdateHotelRoomHandler(ISimpleRepository<HotelRoomEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<HotelRoomDto>> Handle(UpdateHotelRoomCommand command, CancellationToken cancellationToken)
        {
            var hotelRoom = new HotelRoomEntity()
            {
                Name = command.Name,
                RoomNumber = command.RoomNumber,
                GuestCapacity = command.GuestCapacity,
                Area = command.Area,
            };

            var foundHotelRoom = await _repository.GetByIdAsync(command.Id);

            if (foundHotelRoom is null)
                return Error.NotFound(description: $"Hotel room with Id {command.Id} was not found.");

            _mapper.Map(hotelRoom, foundHotelRoom);

            var response = await _repository.UpdateAsync(foundHotelRoom);
            
            var result = _mapper.Map<HotelRoomDto>(response);

            return result;
        }
    }
}
