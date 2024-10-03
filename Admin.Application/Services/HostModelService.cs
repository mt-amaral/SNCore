using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;
using System.Data.SqlTypes;

namespace Admin.Application.Services;

public class HostModelService : IHostModelService
{
    private readonly IHostModelRepository _HostModelRepository;
    private readonly IOidListRepository _oidListRepository;
    private readonly IMapper _mapper;
    public HostModelService(IMapper mapper,
        IHostModelRepository hostModelRepository,
        IOidListRepository oidListRepository)
    {
        _HostModelRepository = hostModelRepository;
        _oidListRepository = oidListRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HostModelPayload>> SelectAll()
    {
        var entityList = await _HostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<HostModelPayload>>(entityList);
    }
    public async Task<IEnumerable<OidPayload>> SelectOid()
    {
        var entitList = await _oidListRepository.SelectByPk(10);
        return _mapper.Map<IEnumerable<OidPayload>>(entitList);
    }
}
