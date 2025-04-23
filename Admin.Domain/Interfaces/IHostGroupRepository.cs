
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHostGroupRepository
{

    Task<HostGroup> GetGroupById(int groupId);
    Task CreateGroupHost(HostGroup hostGroup);
    Task UpdateGroupHost(HostGroup hostGroup);
    Task DeleteGroupHost(HostGroup hostGroup);
    Task<List<HostGroup>> GetInput();
}
