using Admin.Domain.Entities;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Mappings;

public class CronExpressionMapper : Profile
{
    public CronExpressionMapper()
    {
        CreateMap<CronExpression, ExpressionResponse>();
        CreateMap<DataExpressionRequest, CronExpression>();
        
    }
}