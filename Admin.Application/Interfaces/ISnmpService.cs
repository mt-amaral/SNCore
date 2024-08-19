using Admin.Shared.Base;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpResponse> SelectByPk(int id);
    Task<IEnumerable<SnmpResponse>> SelectAll();
    Task Create(SnmpBase snmpRequest);
    Task Edit(int Id, SnmpBase snmpRequest);
    Task Delete(int snmpId);
    Task<SnmpResponse> SelectByHardwareId(int id);
}
