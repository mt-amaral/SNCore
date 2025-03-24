using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Admin.Shared.Response.Model;

namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<ModelResponse>> GetModel();
    Task<IEnumerable<ModelInputResponse>> GetInput();
    Task<IEnumerable<ItemModelResponse>> GetItem(int modelId);

}
