using Application.Features.Hotel.Commands;
using Application.Features.Hotel.Queries;

namespace WebApi.Test.Hotel;
public static class HotelData
{
    public static List<Domain.Entities.Hotel> MockHotelSamples() => new()
    {
        new Domain.Entities.Hotel()
        {
            Name = "AZ Hotels",
            PhoneNumber = "+213673306606",
            Email = "ey_slimani@esi.dz",
            Address = "Algiers",
            Description = "A luxury hotel with a view to the city",
        },
        new Domain.Entities.Hotel()
        {
            Name = "Mariott Hotel",
            PhoneNumber = "+213662617009",
            Email = "yahia.slimani@keywestsystems.com",
            Address = "Constantine",
            Description = "a great hotel but too expensive xD",
        }
    };
    public static GetHotelByIdQuery MockGetHotelByIdQuery() => new() { Id = 1 };

    public static CreateHotelCommand MockCreateHotelCommand() => new()
    {
        Name = "Hotel Tarek",
        PhoneNumber = "+213673547895",
        Email = "tarekhotel@gmail.com",
        Address = "Tebessa",
        Description = "a cheap hotel lol",
    };
    public static UpdateHotelCommand MockUpdateHotelCommand() => new()
    {
        Id = 1,
        Name = "Sheraton Hotel",
        PhoneNumber = "+213555284521",
        Email = "sheraton@gmail.com",
        Address = "Algiers",
        Description = "Luxury",

    };
    public static DeleteHotelByIdCommand MockDeleteHotelByIdCommand() => new() { Id = 2 };

}
