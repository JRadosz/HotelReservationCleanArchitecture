using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.HotelRooms.Commands.CreateHotelRoom
{
    public class UpdateHotelRoomCommand : ICommand<ErrorOr<HotelRoomDto>>
    {
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public int RoomNumber { get; set; }
        public int GuestCapacity { get; set; }
        public float Area { get; set; }
    }
}
