namespace Admin.Domain.Entities.Base;

public abstract class BaseLongEntity
{
    public long Id { get; private set; }
    public bool Active { get; private set; }

    protected BaseLongEntity()
    {
        NewEntity();
    }
    protected void NewEntity()
    {
        Active = true;
    }
    public void Status(bool status)
    {
        Active = status;
    }
}
