using Admin.Domain.Entities;
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
        CreateMap<Snmp, SnmpRequest>().ReverseMap();
        CreateMap<Snmp, SnmpResponse>().ReverseMap();
        CreateMap<Telnet, TelnetRequest>().ReverseMap();
        CreateMap<Telnet, TelnetResponse>().ReverseMap();
    }
}
