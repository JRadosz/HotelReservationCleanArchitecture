using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;

namespace HotelReservation.Application.HotelRooms.Queries.GetAllHotelRooms
{
    public class GetAllHotelRoomsQuery : IQuery<ErrorOr<IEnumerable<HotelRoomDto>>>
    {
    }
}
