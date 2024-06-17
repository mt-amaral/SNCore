using Admin.Application.DTOs;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile() 
    {
        CreateMap<Hardware, HardwareDTO>().ReverseMap();
    }
}
