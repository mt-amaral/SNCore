using Admin.Shared.Response;
using Admin.Shared.Response.Input;

namespace Admin.Application.Interfaces;

public interface IHostService
{
    Task<IEnumerable<HostResponse>> GetHosts();
    Task<IEnumerable<HostInputResponse>> GetInput();
}
