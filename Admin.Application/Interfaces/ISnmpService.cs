
using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpResponse> SelectByPk(int id);
    Task<IEnumerable<SnmpResponse>> SelectAll();
    Task Create(int hardwareId, SnmpPayload snmpRequest);
    Task Edit(int Id, SnmpPayload snmpRequest);
    Task Delete(int snmpId);
    Task<SnmpResponse> SelectByHardwareId(int id);
}
