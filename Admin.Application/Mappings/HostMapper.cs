using Admin.Domain.Entities;
using Admin.Shared.Request.Host;
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
        CreateMap<CreateHostRequest, Host>()
            .ForMember(dest => dest.Snmp, opt => opt.MapFrom(src => src.Snmp))
            .ForMember(dest => dest.Telnet, opt => opt.MapFrom(src => src.Telnet));


        CreateMap<SnmpRequest, Snmp>();
        CreateMap<TelnetRequest, Telnet>();
    }
}