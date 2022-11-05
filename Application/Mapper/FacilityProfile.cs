using Application.Models;
using Application.Features.Facility.Commands;

namespace Application.Mapper;
public class FacilityProfile : Profile
{
    public FacilityProfile()
    {
        CreateMap<Facility, CreateFacilityCommand>();
        CreateMap<CreateFacilityCommand, Facility>();
        CreateMap<UpdateFacilityCommand, Hotel>();
        CreateMap<Facility, FacilityDTO>();
    }
}

