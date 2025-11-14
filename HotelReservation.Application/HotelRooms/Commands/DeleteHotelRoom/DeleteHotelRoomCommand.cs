using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class DeleteHotelRoomCommand : ICommand<ErrorOr<bool>>
    {
        public Guid Id { get; set; }
    }
}
