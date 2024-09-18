using Admin.Shared.Request;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHostService
{

    Task<HostResponse> SelectByPk(int id);
    Task<IEnumerable<HostResponse>> SelectAll();
    Task Create(HostRequest hostCreate);
    Task Edit(int id, HostRequest request);
    Task Delete(int hostId);
}
