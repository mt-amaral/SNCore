using Admin.Domain.Entities;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Mappings;

public class ModelMapper : Profile
{
    public ModelMapper()
    {
        CreateMap<HostModel, ModelResponse>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.ModelName));
    }
}