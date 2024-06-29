using Admin.Domain.Entities;
using AutoMapper;
using ConnectionControl.Application.Dtos;

namespace ConnectionControl.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile() 
    {
        CreateMap<Hardware, HardwareDto>().ReverseMap();
    }
}
