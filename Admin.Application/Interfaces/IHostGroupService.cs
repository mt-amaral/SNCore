using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHostGroupService
{
    Task<IEnumerable<HostGroupResponse>> SelectAll();
    Task CreateHostGroup(HostGroupPayload NewGroup);
}
