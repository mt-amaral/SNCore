using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
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

    public async Task<IEnumerable<HostResponse>> SelectAll()
    {
        var entityList = await _repository.SelectByGroup();
        return _mapper.Map<IEnumerable<HostResponse>>(entityList);
    }

    public async Task<HostResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByHost(id);
        return _mapper.Map<HostResponse>(entity);
    }

    public async Task Create(HostRequest request)
    {
        var entity = _mapper.Map<Host>(request);
        await _repository.Create(entity);
    }

    public async Task Edit(int id, HostRequest request)
    {
        var entity = await _repository.SelectByHost(id);
        _mapper.Map(request, entity);
        await _repository.Edit(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);
    }
}
