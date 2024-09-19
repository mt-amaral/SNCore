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
        

        CreateMap<Host, HostResponse>()
            .ForMember(dest => dest.GroupName, opt => opt.MapFrom(src => src.HostGroup.GroupName))
            .ReverseMap();

        CreateMap<Host, HostGroup>()
            .ForMember(dest => dest.Hosts, opt => opt.MapFrom(src => src));

        CreateMap<Host, HostRequest>().ReverseMap();
        CreateMap<Snmp, SnmpPayload>().ReverseMap();
        CreateMap<Telnet, TelnetPayload>().ReverseMap();
        CreateMap<HostGroup, HostGroupPayload>().ReverseMap();
        CreateMap<HostModel, HostModelPayload>().ReverseMap();


    }
}
