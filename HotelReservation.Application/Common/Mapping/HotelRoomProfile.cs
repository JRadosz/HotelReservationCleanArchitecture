using AutoMapper;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Common.Mapping
{
    public class HotelRoomProfile : Profile
    {

        public HotelRoomProfile()
        {
            CreateMap<HotelRoomEntity, HotelRoomDto>()
                .ReverseMap();

            CreateMap<HotelRoomDto, HotelRoomEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }
}
