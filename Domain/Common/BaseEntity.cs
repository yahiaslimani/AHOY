namespace Domain.Common;
public abstract class BaseEntity
{
    protected BaseEntity()
    {
        CreateTime = DateTime.Now;
        LastModTime = DateTime.Now;
        IsDeleted = false;
    }
    public int Id { get; set; }
    public bool IsDeleted { get; set; }
    public DateTime CreateTime { get; set; }
    public DateTime LastModTime { get; set; }
}
