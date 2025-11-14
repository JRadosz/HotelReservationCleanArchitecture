using Cortex.Mediator.Commands;
using ErrorOr;
using HotelReservation.Application.Reservations.Dtos;

namespace HotelReservation.Application.Reservations.Commands.CreateReservation
{
    public class CreateReservationCommand : ICommand<ErrorOr<int>>
    {
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public float? Price { get; set; }
        public IEnumerable<CustomerRequestDto> Customers { get; set; } = [];
        public IEnumerable<HotelRoomRequestDto> HotelRooms { get; set; } = [];
    }
}
