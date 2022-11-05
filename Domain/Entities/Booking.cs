

namespace Domain.Entities;
public class Booking : BaseEntity
{
    public DateTime CheckIn { get; set; }
    public DateTime CheckOut { get; set; }
    public bool IsConfirmed { get; set; }
    public double Price { get; set; }
    public double Discount { get; set; }
    public double PaidAmount { get; set; }
    public string UserName { get; set; }
    public int RoomId { get; set; }
    public Room Room { get; set; }
}
