using Admin.Shared.Response;
using Admin.Shared.Response.Input;

namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<ModelResponse>> GetModel();
    Task<IEnumerable<ModelInputResponse>> GetModelInput();
    Task<IEnumerable<ItemModelResponse>> GetItem(int modelId);
    
}
