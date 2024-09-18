namespace Admin.Domain.Entities.Base;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public bool Active { get; private set; }

    protected BaseEntity()
    {
        NewEntity();
    }
    protected void NewEntity()
    {
        Active = true;
        CreationDate = DateTime.Now;
    }
    public void UpTime()
    {
        UpdateDate = DateTime.Now;
    }
    public void Status(bool status)
    {
        Active = status;
    }
}
