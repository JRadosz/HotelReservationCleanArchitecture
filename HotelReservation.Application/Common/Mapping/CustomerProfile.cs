using AutoMapper;
using HotelReservation.Application.Customers.Dtos;
using HotelReservation.Application.HotelRooms.Dtos;
using HotelReservation.Application.Reservations.Dtos;
using HotelReservation.Domain.Entities;

namespace HotelReservation.Application.Common.Mapping
{
    public class CustomerProfile : Profile
    {

        public CustomerProfile()
        {
            CreateMap<CustomerEntity, CustomerDto>()
                .ReverseMap();

            CreateMap<CustomerDto, CustomerEntity>()
                .ForMember(dest => dest.Id, opt => opt.Ignore());

            CreateMap<CustomerRequestDto, CustomerEntity>();
               //.ForMember(dest => dest.Id, opt => opt.Ignore());
        }

    }
}
