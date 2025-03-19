namespace Domain.Common;

public class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreatedDate { get; set; } = DateTime.Now;
    public int CreatedBy { get; set; }
    public DateTime ModifiedDate { get; set; } = DateTime.Now;
    public int ModifiedBy { get; set; }
}
