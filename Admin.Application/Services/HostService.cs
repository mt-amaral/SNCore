using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using AutoMapper;

namespace Admin.Application.Services;

public class HostService : IHostService
{
    private readonly IHostRepository _repository;
    private readonly ISnmpRepository _snmpRepository;
    private readonly ITelnetRepository _telnetRepository;
    private readonly IMapper _mapper;
    public HostService(IHostRepository repository,
        IMapper mapper,
        ISnmpRepository snmpRepository,
        ITelnetRepository telnetRepository)
    {
        _telnetRepository = telnetRepository;
        _snmpRepository = snmpRepository;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HostResponse>> GetHosts()
    {
        var entity = await _repository.SelectByGroup();

        var teste = _mapper.Map<List<HostResponse>>(entity);
        return teste;

    }

    public async Task<IEnumerable<HostInputResponse>> GetInput()
    {
        var entity = await _repository.SelectAll();
        var teste = _mapper.Map<List<HostInputResponse>>(entity);
        return teste;
    }


}
