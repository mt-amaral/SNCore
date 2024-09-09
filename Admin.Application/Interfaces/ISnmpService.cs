
using Admin.Shared.Payload;


namespace Admin.Application.Interfaces;

public interface ISnmpService
{
    Task<SnmpPayload> SelectByHardwareId(int id);
}
