using Application.Models.Common;

namespace Application.Models;
public class FacilityDTO
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
}

public class FacilityModel : BaseModel
{
    public FacilityDTO Data { get; set; }
}
public class FacilitiesModel : BaseModel
{
    public List<FacilityDTO> Data { get; set; }
}


