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
        CreateMap<Hardware, HardwareRequest>().ReverseMap();
        CreateMap<Hardware, HardwareResponse>().ReverseMap();
        CreateMap<Hardware, HardwarePayload>().ReverseMap();
        CreateMap<Snmp, SnmpPayload>().ReverseMap();
        CreateMap<Telnet, TelnetPayload>().ReverseMap();
    }
}
