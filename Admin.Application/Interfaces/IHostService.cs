using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
using Admin.Shared.Response.Input;

namespace Admin.Application.Interfaces;

public interface IHostService
{
    Task<IEnumerable<HostResponse>> GetHosts();
    Task<IEnumerable<HostInputResponse>> GetInput();
    Task<HostResponse> GetById(int hostId);
    Task CreateHost(CreateHostRequest newHost);
    Task UpdateHost(CreateHostRequest host, int hostId);
    Task DeletetById(int hostId);

    /// Group
    Task CreateGroupHost(CreateGroupHostRequest newGroup);
    Task UpdateGroupHost(CreateGroupHostRequest newGrou, int groupId);
    Task<List<GroupHostInputResponse>> GetInputGroupHost();
    Task<GroupHostResponse> GetGroupById(int groupId);
    Task DeleteGroupById(int groupId);

}
