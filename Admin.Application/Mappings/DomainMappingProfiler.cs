using Admin.Domain.Entities;
using Admin.Shared.Base;
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
        CreateMap<Hardware, HardwareBase>().ReverseMap();
        CreateMap<Snmp, SnmpRequest>().ReverseMap();
        CreateMap<Snmp, SnmpResponse>().ReverseMap();
        CreateMap<Snmp, SnmpBase>().ReverseMap();
        CreateMap<Telnet, TelnetRequest>().ReverseMap();
        CreateMap<Telnet, TelnetResponse>().ReverseMap();
        CreateMap<Telnet, TelnetBase>().ReverseMap();
    }
}
