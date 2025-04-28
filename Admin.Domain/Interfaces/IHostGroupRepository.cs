
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHostGroupRepository
{
    Task CreateGroupHost(HostGroup hostGroup);
    Task UpdateGroupHost(HostGroup hostGroup);
    Task DeleteGroupHost(HostGroup hostGroup);
}
