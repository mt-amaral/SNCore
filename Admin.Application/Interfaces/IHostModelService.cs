using Admin.Shared.Response;
using Admin.Shared.Response.Input;
using Admin.Shared.Response.Model;

namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<ModelResponse>> GetModel();
    Task<IEnumerable<ModelInputResponse>> GetModelInput();
    Task<IEnumerable<ItemModelResponse>> GetItem(int modelId);

}
