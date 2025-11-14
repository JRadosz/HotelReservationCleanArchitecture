using AutoMapper;
using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class CreateHotelRoomHandler
        : ICommandHandler<CreateHotelRoomCommand, ErrorOr<HotelRoomDto>>
    {
        ISimpleRepository<HotelRoomEntity> _repository;
        IMapper _mapper;

        public CreateHotelRoomHandler(IMapper mapper, ISimpleRepository<HotelRoomEntity> repository)
        {
            _mapper = mapper;
            _repository = repository;
        }

        public async Task<ErrorOr<HotelRoomDto>> Handle(
            CreateHotelRoomCommand command,
            CancellationToken cancellationToken
        )
        {
            var hotelRoom = new HotelRoomEntity()
            {
                Name = command.Name,
                RoomNumber = command.RoomNumber,
                GuestCapacity = command.GuestCapacity,
                Area = command.Area,
            };

            var response = await _repository.AddAsync(hotelRoom);

            var result = _mapper.Map<HotelRoomDto>(response);

            return result;
        }
    }
}
