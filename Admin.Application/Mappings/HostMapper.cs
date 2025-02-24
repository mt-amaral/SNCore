using Admin.Domain.Entities;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using AutoMapper;

namespace Admin.Application.Mappings;

public class HostMapper : Profile
{
    public HostMapper()
    {
        CreateMap<Host, HostResponse>();
        CreateMap<HostResponse, Host>();
        CreateMap<Host, HostInputResponse>();
    }
}