using System;

namespace Admin.Domain.Entities;

public abstract class BaseEntity
{
    public int Id { get; set; }
    public DateTime CreationDate { get; set; }
    public DateTime? UpdateDate { get; set; }
    public bool Active { get; set; }
}
