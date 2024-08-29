
namespace Admin.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; private set; }
    public DateTime CreationDate { get; private set; }
    public DateTime? UpdateDate { get; private set; }
    public bool Active { get; private set; }

    public void NewEntity() 
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
