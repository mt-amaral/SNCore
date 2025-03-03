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
    private readonly IHostGroupRepository _hostGroupRepository;
    private readonly IMapper _mapper;
    public HostService(IHostRepository repository,
        IMapper mapper,
        IHostGroupRepository hostGrouprepository)
    {
        _repository = repository;
        _hostGroupRepository = hostGrouprepository;
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
            await _repository.CreateNewHost(entity);
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

    public async Task CreateGroupHost(CreateGroupHostRequest newGroup)
    {
        try
        {
            var entity = _mapper.Map<HostGroup>(newGroup);
            await _hostGroupRepository.Create(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
    public async Task UpdateGroupHost(CreateGroupHostRequest group, int groupId)
    {
        try
        {
            var entity = await _hostGroupRepository.SelectById(groupId);
             _mapper.Map(group, entity);
            await _hostGroupRepository.Edit(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task<List<GroupHostInputResponse>> GetInputGroupHost()
    {
        try
        {
            var entity = await _hostGroupRepository.SelectAllNoTrack();
            var response = _mapper.Map<List<GroupHostInputResponse>>(entity);
            return response;
        }
        catch
        {
            throw;
        }

    }
    public async Task<GroupHostResponse> GetGroupById(int groupId)
    {
        try
        {
            var entity = await _hostGroupRepository.GetGroupById(groupId);
            var response = _mapper.Map<GroupHostResponse>(entity);
            response.CountHost = entity.Hosts.Count();
            return response;

        }
        catch(Exception ex)
        {
            throw;
        }

    }


    public async Task SelectGroupById(int groupId)
    {
        try
        {
            var entity = await _hostGroupRepository.SelectById(groupId);
            await _hostGroupRepository.Delete(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }

    public async Task DeleteGroupById(int groupId)
    {
        try
        {
            var entity = await _hostGroupRepository.SelectById(groupId);
            await _hostGroupRepository.Delete(entity);
        }
        catch (Exception ex)
        {
            throw;
        }
    }
}
