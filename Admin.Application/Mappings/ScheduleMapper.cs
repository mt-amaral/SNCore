using Admin.Domain.Entities;
using Admin.Shared.Request.Host;
using Admin.Shared.Request.Schedule;
using Admin.Shared.Response.Host;
using AutoMapper;

namespace Admin.Application.Mappings;

public class ScheduleMapper : Profile
{
    public ScheduleMapper()
    {
        CreateMap<CreateScheduleRequest, RunTime>();


    }
}