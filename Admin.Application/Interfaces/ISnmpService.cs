using Admin.Share.Response;
using Admin.Share.Request;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpResponse> SelectByPk(int id);
    Task<IEnumerable<SnmpResponse>> SelectAll();
    Task Create(SnmpRequest snmpRequest);
    Task Edit(SnmpRequest snmpRequest);
    Task Delete(int snmpId);
}
