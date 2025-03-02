using Admin.Domain.Entities;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using AutoMapper;

namespace Admin.Application.Mappings;

public class ModelMapper : Profile
{
    public ModelMapper()
    {
        CreateMap<HostModel, ModelResponse>()
            .ForMember(d => d.Name, opt => opt.MapFrom(src => src.ModelName));

        CreateMap<Item, ItemModelResponse>()
            .ForMember(d => d.OidName, opt => opt.MapFrom(src => src.OidList!.Oid));


        CreateMap<HostModel, ModelInputResponse>();
    }
}