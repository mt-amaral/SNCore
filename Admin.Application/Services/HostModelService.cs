﻿using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Admin.Shared.Response.Model;
using AutoMapper;

namespace Admin.Application.Services;

public class HostModelService : IHostModelService
{
    private readonly IHostModelRepository _hostModelRepository;
    private readonly IItemRepository _itemRepository;
    private readonly IMapper _mapper;
    public HostModelService(IMapper mapper,
        IHostModelRepository hostModelRepository,
        IItemRepository itemRepository)
    {
        _itemRepository = itemRepository;
        _hostModelRepository = hostModelRepository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<ModelResponse>> GetModel()
    {
        var entities = await _hostModelRepository.SelectAll();
        return _mapper.Map<IEnumerable<ModelResponse>>(entities);
    }
    public async Task<IEnumerable<ModelInputResponse>> GetInput()
    {
        var entities = await _hostModelRepository.GetInput();
        return _mapper.Map<IEnumerable<ModelInputResponse>>(entities);
    }

    public async Task<IEnumerable<ItemModelResponse>> GetItem(int modelId)
    {
        var entities = await _itemRepository.GetItemByModel(modelId);
        return _mapper.Map<IEnumerable<ItemModelResponse>>(entities);
    }
}
