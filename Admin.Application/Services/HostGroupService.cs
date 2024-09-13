using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;

namespace Admin.Application.Services;

public class HostGroupService : IHostGroupService
{
    private readonly IHostGroupService _hostGroupService;
    private readonly IMapper _mapper;
    public HostGroupService(IMapper mapper,
        IHostGroupService hostGroupService)
    {
        _hostGroupService = hostGroupService;
        _mapper = mapper;
    }

}
