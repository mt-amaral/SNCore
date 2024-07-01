

using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : BaseService<Snmp, SnmpRequest, SnmpResponse, ISnmpRepository>, ISnmpService
{
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper)
        : base(snmpRepository, mapper)
    {
    }
}
