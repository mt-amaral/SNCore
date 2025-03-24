using Admin.Application.Interfaces;
using Admin.Connection.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request.Host;
using Admin.Shared.Request.Connection;
using Admin.Shared.Response.Host;
using Admin.Shared.Response.Input;
using AutoMapper;
using Lextm.SharpSnmpLib;

namespace Admin.Application.Services;

public class SnmpService : ISnmpService
{
    private readonly ISnmpConnection _snmpConnection;
    private readonly IHostRepository _hostRepository;
    private readonly IMapper _mapper;
    public SnmpService(IMapper mapper, ISnmpConnection snmpConnection, IHostRepository hostRepository)
    {
        _snmpConnection = snmpConnection;
        _hostRepository = hostRepository;
        _mapper = mapper;
    }

}
