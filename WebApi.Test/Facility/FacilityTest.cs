using Application.Models;
using Application.Features.Facility.Queries;
using static Application.Features.Facility.Queries.GetAllFacilitiesQuery;
using static Application.Features.Facility.Queries.GetFacilityByIdQuery;
using static Application.Features.Facility.Commands.CreateFacilityCommand;
using static Application.Features.Facility.Commands.UpdateFacilityCommand;
using static Application.Features.Facility.Commands.DeleteFacilityByIdCommand;

namespace WebApi.Test.Lookup.Facility;
public class FacilityTest : IClassFixture<SharedDatabaseFixture>
{
    public SharedDatabaseFixture Fixture { get; }
    private readonly Mock<IApplicationDbContext> _mockContext;


    public FacilityTest(SharedDatabaseFixture fixture)
    {
        Fixture = fixture;
        _mockContext = new Mock<IApplicationDbContext>();
        _mockContext.Setup(db => db.Facilities).Returns(SharedDatabaseFixture.CreateContext().Facilities);
    }


    [Fact]
    public async Task Can_Get_All_Facilities()
    {
        GetAllFacilityQueryHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await handler.Handle(new GetAllFacilitiesQuery (), CancellationToken.None);
        List<FacilityDTO> facility = result.Data;
        Assert.NotNull(facility);
        Assert.Equal(FacilityData.MockFacilitySamples()[0].Name, facility[0].Name);
    }


    [Fact]
    public async Task Can_Get_Facility_By_Id()
    {
        GetFacilityByIdQueryHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await handler.Handle(FacilityData.MockGetFacilityByIdQuery(), CancellationToken.None);
        var facility = result.Data;

        Assert.Equal(FacilityData.MockFacilitySamples()[0].Name, facility.Name);
    }


    [Fact]
    public async Task Can_Add_Facility()
    {
        CreateFacilityCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await handler.Handle(FacilityData.MockCreateFacilityCommand(), CancellationToken.None);
        var facility = result.Data;

        Assert.Equal(FacilityData.MockCreateFacilityCommand().Name, facility.Name);
    }


    [Fact]
    public async Task Can_Update_Facility()
    {
        UpdateFacilityCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await handler.Handle(FacilityData.MockUpdateFacilityCommand(), CancellationToken.None);
        var facility =  result.Data;

        Assert.Equal(FacilityData.MockUpdateFacilityCommand().Name, facility.Name);
    }


    [Fact]
    public async Task Can_Delete_Facility()
    {
        DeleteFacilityByIdCommandHandler handler = new(_mockContext.Object, MockServices.GetMockedMapper<IMapper>());
        var result = await handler.Handle(FacilityData.MockDeleteFacilityByIdCommand(), CancellationToken.None);
        var facility =  result.Data;

        Assert.Equal(FacilityData.MockFacilitySamples()[0].Name, facility.Name);
    }
}




