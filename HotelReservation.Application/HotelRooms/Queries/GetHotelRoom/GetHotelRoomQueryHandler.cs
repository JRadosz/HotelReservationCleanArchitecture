using AutoMapper;
using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Queries.GetHotelRoom
{
    public class GetHotelRoomQueryHandler : IQueryHandler<GetHotelRoomQuery, ErrorOr<HotelRoomDto>>
    {
        ISimpleRepository<HotelRoomEntity> _repository;
        IMapper _mapper;

        public GetHotelRoomQueryHandler(ISimpleRepository<HotelRoomEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<HotelRoomDto>> Handle(GetHotelRoomQuery query, CancellationToken cancellationToken)
        {
            var hotelRoom = await _repository.GetByIdAsync(query.HotelRoomId);

            if (hotelRoom?.Id != query.HotelRoomId)
            {
                return Error.NotFound(description: "Hotel room not found");
            }

            var result = _mapper.Map<HotelRoomDto>(hotelRoom);

            return result;
        }
    }
}
