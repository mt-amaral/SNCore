using Admin.Shared.Payload;


namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<HostModelPayload>> SelectAll();
}
