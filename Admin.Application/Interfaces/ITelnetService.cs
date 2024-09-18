
using Admin.Shared.Payload;


namespace Admin.Application.Interfaces;

public interface ITelnetService
{
    Task<TelnetPayload> SelectByHostId(int id);
}
