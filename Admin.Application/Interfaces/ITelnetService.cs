using Admin.Shared.Base;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetResponse> SelectByPk(int id);
    Task<IEnumerable<TelnetResponse>> SelectAll();
    Task Create(TelnetBase telnetRequest);
    Task Edit(int Id, TelnetBase telnetRequest);
    Task Delete(int snmpId);
}
