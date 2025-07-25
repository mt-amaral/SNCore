﻿using Admin.Domain.Entities;
using Admin.Shared.Request.Expression;
using Admin.Shared.Response.Expression;
using AutoMapper;

namespace Admin.Application.Mappings;

public class ExpressionMapper : Profile
{
    public ExpressionMapper()
    {
        CreateMap<CronExpression, ExpressionResponse>();

        CreateMap<CronExpression, GetExpressionResponse>();
        CreateMap<ExpressionRequest, CronExpression>();
    }
}
