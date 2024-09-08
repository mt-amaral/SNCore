﻿using Admin.Shared.Payload;
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


        CreateMap<SnmpPayload, HardwareResponse>()
            .ForMember(dest => dest.Snmp, opt => opt.MapFrom(src => src));
        CreateMap<TelnetPayload, HardwareResponse>()
    .       ForMember(dest => dest.Telnet, opt => opt.MapFrom(src => src));
    }
}