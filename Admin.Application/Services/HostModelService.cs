using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Response;
using AutoMapper;
using System.Data.SqlTypes;

namespace Admin.Application.Services;

public class HostModelService : IHostModelService
{
    private readonly IHostModelRepository _HostModelRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    public HostModelService(IMapper mapper,
        IHostModelRepository hostModelRepository,
        IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
        _HostModelRepository = hostModelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HostModelPayload>> SelectAll()
    {
        var entityList = await _HostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<HostModelPayload>>(entityList);
    }
    public async Task<IEnumerable<ItemByModelResponse>> GetItemByModel(int modelId)
    {
        var entityList = await _itemRepository.GetItemByModel(modelId);
        return _mapper.Map<IEnumerable<ItemByModelResponse>>(entityList);
    }
}
