
using Admin.Domain.Entities;
using Admin.Domain.Interfaces.Base;

namespace Admin.Domain.Interfaces;

public interface IHostGroupRepository : IBaseRepository<HostGroup>
{


     Task<HostGroup> GetGroupById(int groupId);
}
