using Admin.Shared.Request.Host;
using Admin.Shared.Response;
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

}
