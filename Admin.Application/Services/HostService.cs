using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
using Admin.Shared.Response.Input;
using AutoMapper;

namespace Admin.Application.Services;

public class HostService : IHostService
{
    private readonly IHostRepository _repository;
    private readonly IMapper _mapper;
    public HostService(IHostRepository repository,
        IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HostResponse>> GetHosts()
    {
        var entity = await _repository.SelectByGroup();

        var response = _mapper.Map<List<HostResponse>>(entity);
        return response;

    }
    public async Task<HostResponse> GetById(int hostId)
    {
        try
        {
            var entity = await _repository.SelectByHost(hostId);
            var response = _mapper.Map<HostResponse>(entity);
            return response;
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<IEnumerable<HostInputResponse>> GetInput()
    {
        var entity = await _repository.SelectAll();
        var response = _mapper.Map<List<HostInputResponse>>(entity);
        return response;
    }

    public async Task CreateHost(CreateHostRequest newHost)
    {
        try
        {
            var entity = _mapper.Map<Host>(newHost);
            await _repository.CreateHost(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }


    public async Task UpdateHost(CreateHostRequest host, int hostId)
    {
        try
        {
            var entity = await _repository.SelectByHost(hostId);
            _mapper.Map(host, entity);
            await _repository.UpdateHost(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeletetById(int hostId)
    {
        try
        {
            var entity = await _repository.SelectByHost(hostId);
            await _repository.DeleteHost(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
