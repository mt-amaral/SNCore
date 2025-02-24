using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using AutoMapper;

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

    public async Task<IEnumerable<ModelResponse>> GetModel()
    {
        var entities = await _HostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<ModelResponse>>(entities);
    }    
    public async Task<IEnumerable<ModelInputResponse>> GetModelInput()
    {
        var entities = await _HostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<ModelInputResponse>>(entities);
    }

    public async Task<IEnumerable<ItemModelResponse>> GetItem(int modelId)
    {
        var entities = await _itemRepository.GetItemByModel(modelId);
        return _mapper.Map<IEnumerable<ItemModelResponse>>(entities);
    }
}
