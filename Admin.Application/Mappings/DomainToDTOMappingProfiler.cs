using Admin.Share.Response;
using Admin.Domain.Entities;
using AutoMapper;

namespace Admin.Application.Mappings;

public class DomainToDTOMappingProfile : Profile
{
    public DomainToDTOMappingProfile() 
    {
        CreateMap<Hardware, HardwareResponse>().ReverseMap();
    }
}
