using Application.Features.Booking.Commands;

namespace WebApi.Test.Booking;
public static class BookingData
{
    public static CreateBookingCommand MockCreateBookingCommand() => new()
    {
        UserName = "Yahia Slimani",
        CheckIn = DateTime.Now,
        CheckOut = DateTime.Now.AddDays(7),
        Price = 12345,
        Discount = 250,
        IsConfirmed = true,
        PaidAmount = 11000,
        RoomId = 1
    };
}
