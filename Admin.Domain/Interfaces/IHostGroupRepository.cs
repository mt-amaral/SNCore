
using Admin.Domain.Entities;
using Admin.Shared.Request.Host;

namespace Admin.Domain.Interfaces;

public interface IHostGroupRepository
{
    Task CreateGroup(HostGroup hostGroup);
    Task UpdateGroup(HostGroup hostGroup);
    Task DeleteGroupRange(List<HostGroup?> entity);
    Task<HostGroup?> SelectByGrup(int id);
    Task<IEnumerable<HostGroup?>> FilteredGroup(GroupHostFilter filter);
}
