using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.App.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HostPayload, HostRequest>().ReverseMap();
        CreateMap<HostPayload, HostResponse>().ReverseMap();
        CreateMap<HostResponse, HostRequest>().ReverseMap();


        CreateMap<SnmpPayload, HostRequest>()
            .ForMember(dest => dest.Snmp, opt => opt.MapFrom(src => src));
        CreateMap<TelnetPayload, HostRequest>()
    .ForMember(dest => dest.Telnet, opt => opt.MapFrom(src => src));
    }
}