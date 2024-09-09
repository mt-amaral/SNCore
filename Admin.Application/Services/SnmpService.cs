
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : ISnmpService
{
    private readonly ISnmpRepository _repository;
    private readonly IHardwareRepository _hardwareRepository;
    private readonly IMapper _mapper;
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper,
        IHardwareRepository hardwareRepository)
    {
        _repository = snmpRepository;
        _hardwareRepository = hardwareRepository;
        _mapper = mapper;
    }

    public async Task<SnmpPayload> SelectByHardwareId(int id)
    {
        var snmp = await _repository.SelectByHardwareId(id);
        return _mapper.Map<SnmpPayload>(snmp);
    }
}
