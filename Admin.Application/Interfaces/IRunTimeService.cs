using Admin.Domain.Entities;
using Admin.Shared.Request.Schedule;
using Admin.Shared.Response;

namespace Admin.Application.Interfaces;

public interface IRunTimeService
{
    Task<Response<string?>> Create(CreateScheduleRequest request);
}