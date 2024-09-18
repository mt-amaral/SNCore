
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : ISnmpService
{
    private readonly ISnmpRepository _repository;
    private readonly IHostRepository _hostRepository;
    private readonly IMapper _mapper;
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper,
        IHostRepository hostRepository)
    {
        _repository = snmpRepository;
        _hostRepository = hostRepository;
        _mapper = mapper;
    }

    public async Task<SnmpPayload> SelectByHostId(int id)
    {
        var snmp = await _repository.SelectByHostId(id);
        return _mapper.Map<SnmpPayload>(snmp);
    }
}
