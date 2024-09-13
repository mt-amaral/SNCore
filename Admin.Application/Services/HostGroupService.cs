using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
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
    public async Task<ICollection<HostGroupPayload>> SelectAll()
    {
        var entityList = await _hostGroupRepository.SelectAllColection();
        return _mapper.Map<ICollection<HostGroupPayload>>(entityList);
    }
}
