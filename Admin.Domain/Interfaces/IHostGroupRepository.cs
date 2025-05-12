
using Admin.Domain.Entities;

namespace Admin.Domain.Interfaces;

public interface IHostGroupRepository
{
    Task CreateGroup(HostGroup hostGroup);
    Task UpdateGroup(HostGroup hostGroup);
    Task DeleteGroup(HostGroup hostGroup);
    Task<HostGroup?> SelectByGrup(int id);

    Task<IEnumerable<HostGroup?>> FilteredGroup(
        int pageNumber = 1,
        int pageSize = 20);
}
