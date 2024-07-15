

using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
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

    public SnmpResponse SnmpSelectByHarware(int id) 
    {
        var snmp = _snmpRepository.SelectByHardware(id);
        return _mapper.Map<SnmpResponse>(snmp);
        
    }
}
