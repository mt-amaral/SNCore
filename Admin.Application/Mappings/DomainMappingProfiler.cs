using Admin.Domain.Entities;
using Admin.Share.Request;
using Admin.Share.Response;
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
