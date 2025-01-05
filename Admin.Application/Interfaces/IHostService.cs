using Admin.Shared.Response;

namespace Admin.Application.Interfaces;

public interface IHostService
{
    Task<IEnumerable<HostResponse>> GetHosts();
}
