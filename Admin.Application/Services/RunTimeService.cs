using Admin.Application.Interfaces;
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

    public RunTimeService(IRunTimeRepository repository, IMapper mapper)
    {
        _mapper = mapper;
        _repository = repository;
    }
    
    public async Task<Response<string?>> Create(CreateScheduleRequest request)
    {
        var entity = _mapper.Map<RunTime>(request);
        await _repository.Create(entity);
        return new Response<string?>();
    }

}
