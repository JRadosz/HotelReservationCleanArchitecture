using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.HotelRooms.Queries.GetHotelRoom
{
    public class GetHotelRoomQuery : IQuery<ErrorOr<HotelRoomDto>>
    {
        public Guid HotelRoomId { get; set; }
    }
}
