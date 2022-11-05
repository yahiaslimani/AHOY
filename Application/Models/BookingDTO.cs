using Application.Models.Common;

namespace Application.Models;
public class BookingDto
{
    public int Id { get; set; }
    public string UserName { get; set; }
    public RoomDTO Room { get; set; }
}

public class BookingModel : BaseModel
{
    public BookingDto Data { get; set; }
}
