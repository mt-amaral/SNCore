using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;

namespace Admin.Application.Services;

public class HostModelService : IHostModelService
{
    private readonly IHostModelRepository _HostModelRepository;
    private readonly IMapper _mapper;
    public HostModelService(IMapper mapper,
        IHostModelRepository hostModelRepository)
    {
        _HostModelRepository = hostModelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HostModelPayload>> SelectAll()
    {
        var entityList = await _HostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<HostModelPayload>>(entityList);
    }
}
