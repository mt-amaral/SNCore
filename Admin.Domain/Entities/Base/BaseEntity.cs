namespace Admin.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }

    protected BaseEntity()
    {
        NewEntity();
    }
    protected void NewEntity()
    {
        CreationDate = DateTime.Now;
    }
    public void UpTime()
    {
        UpdateDate = DateTime.Now;
    }
}
