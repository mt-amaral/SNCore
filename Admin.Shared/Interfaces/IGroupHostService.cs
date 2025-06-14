using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Host;

namespace Admin.Shared.Interfaces;

public interface IGroupHostService
{
    Task<Response<GroupHostResponse?>> CreateHostGroup(CreateGroupHostRequest request);
    Task<Response<GroupHostResponse?>> UpdateHostGroup(CreateGroupHostRequest request,int id);
    Task<Response<Dictionary<int, string>?>> GroupAddHostList(int idGroup, List<int> hostIds);
    Task<Response<GroupHostResponse?>> DeleteHostGroup(int id);
    Task<Response<List<GroupHostResponse?>>> GetHostGroupList(int pageNumber = 1, int pageSize = 20);
}
