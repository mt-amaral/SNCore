﻿using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile() 
    {
        CreateMap<Hardware, HardwareRequest>().ReverseMap();
        CreateMap<Hardware, HardwareResponse>().ReverseMap();
    }
}
