
using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpPayload> SelectByHardwareId(int id);
}
