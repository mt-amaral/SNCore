
using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetPayload> SelectByHardwareId(int id);
}
