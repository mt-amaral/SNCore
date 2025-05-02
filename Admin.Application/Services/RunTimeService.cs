using Admin.Application.Interfaces;
using Admin.Application.Scheduling;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Schedule;
using Admin.Shared.Response;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace Admin.Application.Services;

public class RunTimeService : IRunTimeService
{
    private readonly IRunTimeRepository _repository;
    private readonly IMapper _mapper;
    private readonly JobScheduler _jobScheduler;

    public RunTimeService(IRunTimeRepository repository, IMapper mapper, JobScheduler jobScheduler)
    {
        _mapper = mapper;
        _repository = repository;
        _jobScheduler = jobScheduler;
    }
    
    public async Task<Response<string?>> Create(CreateScheduleRequest request)
    {
        try
        {
            var entity = _mapper.Map<RunTime>(request);
            await _repository.Create(entity);
            return new Response<string?>();
        }
        catch
        {
            return new Response<string?>(null, 500, "Erro ao cadastrar nova rotina");
        }
    }

    public async Task<Response<string?>> ScheduleStatus(Guid id, bool status = false)
    {
        var entity = await _repository.GetById(id);
        if(entity is null) 
            return new Response<string?>(null, 404, "Rotina não encontrada");

        entity.Activate(status);
        await _repository.Update(entity);
        if (status)
            await _jobScheduler.AddJobAsync(entity);
        else
            await _jobScheduler.RemoveJobAsync(entity.Id);
            
        return new Response<string?>(null, 201, "Rotina ");

    }

}
