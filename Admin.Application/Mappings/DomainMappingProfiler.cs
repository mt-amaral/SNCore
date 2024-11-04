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

        CreateMap<Item, ItemByModelResponse>()
            .ForMember(dest => dest.Oid, opt => opt.MapFrom(src => src.OidList.Oid))
            .ReverseMap();

        CreateMap<Host, HostGroup>()
            .ForMember(dest => dest.Hosts, opt => opt.MapFrom(src => src));

        CreateMap<OidList, OidPayload>().ReverseMap();
        CreateMap<Host, HostRequest>().ReverseMap();
        CreateMap<Snmp, SnmpPayload>().ReverseMap();
        CreateMap<Telnet, TelnetPayload>().ReverseMap();
        CreateMap<HostGroup, HostGroupPayload>().ReverseMap();
        CreateMap<HostGroup, HostGroupPayload>().ReverseMap();
        CreateMap<HostGroup, HostGroupResponse>().ReverseMap();
        CreateMap<HostModel, HostModelPayload>().ReverseMap();
    }
}
