using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Response.Host;
using Admin.Shared.Response.Input;
using AutoMapper;

namespace Admin.Application.Services;

public class HostGroupService : IHostGroupService
{
    private readonly IHostGroupRepository _hostGroupRepository;
    private readonly IMapper _mapper;
    public HostGroupService(
        IMapper mapper,
        IHostGroupRepository hostGroupRepository)
    {
        _hostGroupRepository = hostGroupRepository;
        _mapper = mapper;
    }
    
    public async Task CreateGroupHost(CreateGroupHostRequest newGroup)
    {
        var entity = _mapper.Map<HostGroup>(newGroup);
        await _hostGroupRepository.CreateGroupHost(entity);
    }
    
    public async Task UpdateGroupHost(CreateGroupHostRequest group, int groupId)
    {

        var entity = await _hostGroupRepository.GetGroupById(groupId);
         _mapper.Map(group, entity);
        await _hostGroupRepository.UpdateGroupHost(entity);
    }

    public async Task<List<GroupHostInputResponse>> GetInput()
    {

        var entity = await _hostGroupRepository.GetInput();
        var response = _mapper.Map<List<GroupHostInputResponse>>(entity);
        return response;
    }
    public async Task<GroupHostResponse> GetGroupById(int groupId)
    {

        var entity = await _hostGroupRepository.GetGroupById(groupId);
        var response = _mapper.Map<GroupHostResponse>(entity);
        response.CountHost = entity.Hosts.Count();
        return response;
    }
    
    public async Task DeleteGroupById(int groupId)
    {
        var entity = await _hostGroupRepository.GetGroupById(groupId);
        await _hostGroupRepository.DeleteGroupHost(entity);
    }
}
