using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Host;

namespace Admin.Application.Interfaces;

public interface IHostService
{
    Task<Response<HostResponse?>> CreateHost(CreateHostRequest request);
    Task<Response<HostResponse?>> UpdateHost(CreateHostRequest request,int id);
}
