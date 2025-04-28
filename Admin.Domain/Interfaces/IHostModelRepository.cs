

using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHostModelRepository
{
    Task<List<HostModel>> SelectAll();
}
