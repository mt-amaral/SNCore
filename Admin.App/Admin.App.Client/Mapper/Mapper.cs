using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;

namespace Admin.App.Client.Mapper;

public static class Mapper
{
    public static CreateGroupHostRequest MapToEditGroup(GroupHostResponse response)
    {
        return new()
        {
            GroupName = response.GroupName,
        };
    }
    
}