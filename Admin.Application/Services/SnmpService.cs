

using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Share.Request;
using Admin.Share.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : BaseService<Snmp, SnmpRequest, SnmpResponse, ISnmpRepository>, ISnmpService
{
    private readonly ISnmpRepository _snmpRepository;
    private readonly IMapper _mapper;
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper)
        : base(snmpRepository, mapper)
    {
        _snmpRepository = snmpRepository;
        _mapper = mapper;
    }

    public async Task<SnmpResponse> SelectByHardwareId(int id)
    {
        var snmp = await _snmpRepository.SelectByHardwareId(id);
        return _mapper.Map<SnmpResponse>(snmp);
    }
}
