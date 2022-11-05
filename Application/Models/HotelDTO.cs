using Application.Models.Common;

namespace Application.Models;
public class HotelDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public virtual List<FacilityDTO> Facilities { get; set; }
    public virtual List<HotelImageDTO> Images { get; set; }
    public virtual List<RoomDTO> Rooms { get; set; }
    public virtual List<ReviewDTO> Reviews { get; set; }
}

public class HotelModel : BaseModel
{
    public HotelDTO Data { get; set; }
}
public class HotelsModel : BaseModel
{
    public List<HotelDTO> Data { get; set; }
}


