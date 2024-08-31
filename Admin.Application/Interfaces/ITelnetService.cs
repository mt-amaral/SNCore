
using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetResponse> SelectByPk(int id);
    Task<IEnumerable<TelnetResponse>> SelectAll();
    Task Create(TelnetPayload telnetRequest);
    Task Edit(int Id, TelnetPayload telnetRequest);
    Task Delete(int snmpId);
    Task<SnmpResponse> SelectByHardwareId(int id);
}
