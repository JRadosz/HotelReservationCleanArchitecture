using AutoMapper;
using Cortex.Mediator.Queries;
using ErrorOr;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Domain.Entities;
using HotelReservation.Domain.Repositories;

namespace HotelReservation.Application.HotelRooms.Queries.GetAllHotelRooms
{
    public class GetAllHotelRoomsQueryHandler : IQueryHandler<GetAllHotelRoomsQuery, ErrorOr<IEnumerable<HotelRoomDto>>>
    {
        ISimpleRepository<HotelRoomEntity> _repository;
        IMapper _mapper;

        public GetAllHotelRoomsQueryHandler(ISimpleRepository<HotelRoomEntity> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ErrorOr<IEnumerable<HotelRoomDto>>> Handle(GetAllHotelRoomsQuery query, CancellationToken cancellationToken)
        {
            var hotelRoom = await _repository.GetAllAsync();

            var result = _mapper.Map<IEnumerable<HotelRoomDto>>(hotelRoom).ToList();

            return result;
        }
    }
}
