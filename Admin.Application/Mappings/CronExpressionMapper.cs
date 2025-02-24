using Admin.Domain.Entities;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Mappings;

public class CronExpressionMapper : Profile
{
    public CronExpressionMapper()
    {
        CreateMap<CronExpression, ExpressionResponse>()
            .ForMember(d => d.HostName, opt => opt.MapFrom(src => src.Host!.Name))
            .ForMember(d => d.ItemName, opt => opt.MapFrom(src => src.Item.ItemName))
            .ForMember(dest => dest.Expression, opt => opt.MapFrom(src => 
                $"{src.Second} {src.Minute} {src.Hour} {src.Day} {src.Month} {src.Weesday}"));
        CreateMap<DataExpressionRequest, CronExpression>();
        
    }
}