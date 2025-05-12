using Admin.Domain.Entities;
using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
using AutoMapper;

namespace Admin.Application.Mappings;

public class HostMapper : Profile
{
    public HostMapper()
    {
        CreateMap<CreateHostRequest, Host>()
            .ForMember(dest => dest.Snmp, opt => opt.MapFrom(src => src.Snmp))
            .ForMember(dest => dest.Telnet, opt => opt.MapFrom(src => src.Telnet));
        CreateMap<Host, HostResponse>()
            .ForMember(dest => dest.Snmp, opt => opt.MapFrom(src => src.Snmp))
            .ForMember(dest => dest.Telnet, opt => opt.MapFrom(src => src.Telnet))
            .ForMember(dest => dest.GroupHost, opt => opt.MapFrom(src => src.HostGroup));
        CreateMap<SnmpRequest, Snmp>();
        CreateMap<TelnetRequest, Telnet>();
        
        /// GroupHost
        CreateMap<HostGroup, GroupHostResponse>()
            .ForMember(dest => dest.CountHost, opt => opt.MapFrom(src => src.Hosts.Count));
        CreateMap<CreateGroupHostRequest, HostGroup>();
    }
}