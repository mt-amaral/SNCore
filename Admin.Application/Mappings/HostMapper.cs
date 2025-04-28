using Admin.Domain.Entities;
using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
using AutoMapper;

namespace Admin.Application.Mappings;

public class HostMapper : Profile
{
    public HostMapper()
    {
        CreateMap<CreateHostRequest, Host>();
        CreateMap<Host, HostResponse>();

    }
}