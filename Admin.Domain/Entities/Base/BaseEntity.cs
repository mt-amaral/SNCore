namespace Admin.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; init; }
    public DateTime CreationDate { get; init; } = DateTime.Now;
    public DateTime? UpdateDate { get; private set; }

    public void UpTime()
    {
        UpdateDate = DateTime.Now;
    }
}
