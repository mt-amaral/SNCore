using Admin.Domain.Entities;
using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Mappings;

public class DomainMappingProfile : Profile
{
    public DomainMappingProfile()
    {
        CreateMap<Host, HostRequest>().ReverseMap();
        CreateMap<Host, HostResponse>().ReverseMap();
        CreateMap<Host, HostPayload>().ReverseMap();
        CreateMap<Snmp, SnmpPayload>().ReverseMap();
        CreateMap<Telnet, TelnetPayload>().ReverseMap();
    }
}
