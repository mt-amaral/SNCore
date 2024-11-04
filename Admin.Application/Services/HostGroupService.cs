using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class HostGroupService : IHostGroupService
{
    private readonly IHostGroupRepository _hostGroupRepository;
    private readonly IMapper _mapper;
    public HostGroupService(IMapper mapper,
        IHostGroupRepository hostGroupRepository)
    {
        _hostGroupRepository = hostGroupRepository;
        _mapper = mapper;
    }
    public async Task<IEnumerable<HostGroupResponse>> SelectAll()
    {
        var entityList = await _hostGroupRepository.SelectAll();
        return _mapper.Map<IEnumerable<HostGroupResponse>>(entityList);
    }
    public async Task CreateHostGroup(HostGroupPayload NewGroup)
    {
        var entity = _mapper.Map<HostGroup>(NewGroup);
        await _hostGroupRepository.Create(entity);
    }
}
