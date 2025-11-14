using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class CreateHotelRoomCommand : ICommand<ErrorOr<HotelRoomDto>>
    {
        public string? Name { get; set; }
        public int RoomNumber { get; set; }
        public int GuestCapacity { get; set; }
        public float Area { get; set; }
    }
}
