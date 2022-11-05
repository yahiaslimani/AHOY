using Application.Features.Facility.Commands;
using Application.Features.Facility.Queries;

namespace WebApi.Test.Lookup.Facility;
public static class FacilityData
{
    public static List<Domain.Entities.Facility> MockFacilitySamples() => new()
    {
        new Domain.Entities.Facility()
        {
            Name = "Swimming Pool"
        },
        new Domain.Entities.Facility()
        {
            Name = "Swimming Pool",
        }
    };

    public static GetFacilityByIdQuery MockGetFacilityByIdQuery() => new() { Id = 1 };
    public static CreateFacilityCommand MockCreateFacilityCommand() => new() { Name = "SPA" };
    public static UpdateFacilityCommand MockUpdateFacilityCommand() => new() { Id = 1, Name = "Cozy beds" };
    public static DeleteFacilityByIdCommand MockDeleteFacilityByIdCommand() => new() { Id = 2 };

}
