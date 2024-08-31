using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.App.Mappings;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<HardwarePayload, HardwareRequest>().ReverseMap();
        CreateMap<HardwarePayload, HardwareResponse>().ReverseMap();
        CreateMap<SnmpPayload, SnmpRequest>().ReverseMap();
        CreateMap<SnmpPayload, SnmpResponse>().ReverseMap();
        CreateMap<TelnetPayload, TelnetRequest>().ReverseMap();
        CreateMap<TelnetPayload, TelnetResponse>().ReverseMap();
    }
}