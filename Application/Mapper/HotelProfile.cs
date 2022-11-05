using Application.Models;
using Application.Features.Hotel.Commands;

namespace Application.Mapper;
public class HotelProfile : Profile
{
    public HotelProfile()
    {
        CreateMap<Hotel, CreateHotelCommand>();
        CreateMap<CreateHotelCommand, Hotel>();
        CreateMap<UpdateHotelCommand, Hotel>();
        CreateMap<Hotel, HotelDTO>()
         .ForMember(from => from.Rooms, to => to.MapFrom(value => value.Rooms))
         .ForMember(from => from.Reviews, to => to.MapFrom(value => value.Reviews))
         .ForMember(from => from.Facilities, to => to.MapFrom(value => value.HotelFacilities));

        CreateMap<Review, ReviewDTO>();
        CreateMap<Room, RoomDTO>()
               .ForMember(from => from.Hotel, to => to.MapFrom(value => value.Hotel))
            ;

        CreateMap<HotelImage, HotelImageDTO>();
        CreateMap<HotelFacility, FacilityDTO>()
               .ForMember(from => from.Name, to => to.MapFrom(value => value.Facility.Name))
               .ForMember(from => from.Description, to => to.MapFrom(value => value.Facility.Description))
            ;
    }
}

