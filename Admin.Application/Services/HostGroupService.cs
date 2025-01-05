using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
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
}
