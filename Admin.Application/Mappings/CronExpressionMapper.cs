using Admin.Domain.Entities;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
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

        CreateMap<CreateExpressionRequest, CronExpression>()
            .ForMember(dest => dest.Second, opt => opt.MapFrom(src => src.Expression.Second))
            .ForMember(dest => dest.Minute, opt => opt.MapFrom(src => src.Expression.Minute))
            .ForMember(dest => dest.Hour, opt => opt.MapFrom(src => src.Expression.Hour))
            .ForMember(dest => dest.Day, opt => opt.MapFrom(src => src.Expression.Day))
            .ForMember(dest => dest.Month, opt => opt.MapFrom(src => src.Expression.Month))
            .ForMember(dest => dest.Weesday, opt => opt.MapFrom(src => src.Expression.Weesday))
            .ForMember(dest => dest.ItemId, opt => opt.MapFrom(src => src.ItemId))
            .ForMember(dest => dest.HostId, opt => opt.MapFrom(src => src.HostId));
    }
}