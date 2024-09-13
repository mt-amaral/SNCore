using Admin.Shared.Request;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHostGroupService
{
    Task<IEnumerable<HostResponse>> SelectAll();
}
