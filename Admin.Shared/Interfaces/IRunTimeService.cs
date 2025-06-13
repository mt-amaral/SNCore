using Admin.Shared.Request.Schedule;
using Admin.Shared.Response;

namespace Admin.Shared.Interfaces;

public interface IRunTimeService
{
    Task<Response<string?>> Create(CreateScheduleRequest request);
    Task<Response<string?>> ScheduleStatus(Guid id,bool status = false);

}