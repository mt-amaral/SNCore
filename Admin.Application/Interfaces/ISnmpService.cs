using Admin.Shared.Response;
using Admin.Shared.Request;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpResponse> SelectByPk(int id);
    Task<IEnumerable<SnmpResponse>> SelectAll();
    Task Create(SnmpRequest snmpRequest);
    Task Edit(SnmpRequest snmpRequest);
    Task Delete(int snmpId);
    Task<SnmpResponse> SelectByHardwareId(int id);
}
