using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
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
}
