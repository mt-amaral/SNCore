using Admin.Shared.Payload;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<HostModelPayload>> SelectAll();
    Task<IEnumerable<ItemByModelResponse>> GetItemByModel(int modelId);
}
