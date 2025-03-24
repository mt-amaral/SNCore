

using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHostModelRepository
{
    Task<List<HostModel>> GetInput();
    Task<List<HostModel>> SelectAll();
}
