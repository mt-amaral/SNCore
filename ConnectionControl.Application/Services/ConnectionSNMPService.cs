using AutoMapper;
using ConnectionControl.Application.Dtos.Request;
using ConnectionControl.Application.Interfaces;
using ConnectionsControl.ConnectionLibrary.Interfaces;

namespace ConnectionControl.Application.Services;

public class ConnectionSNMPService : IConnectionSNMPService
{
    private readonly IDataConnection _dataConnection;
    private readonly IMapper _mapper;
    public ConnectionSNMPService(IDataConnection dataConnection, IMapper mapper)
    {
        _dataConnection = dataConnection;
        _mapper = mapper;
    }

    public async Task SimpleSNPM(ConnectionSNMPDto connectionSNMPD)
    {
        try
        {
            var resultado = _dataConnection.PerformSnmpOperation(connectionSNMPD.Ipv4, connectionSNMPD.Port, connectionSNMPD.Community, connectionSNMPD.Oid);
        }
        catch (Exception ex)
        {
            throw new Exception($"Erro de conexão com {connectionSNMPD.Ipv4}. Erro: {ex}");
        }
    }
}
