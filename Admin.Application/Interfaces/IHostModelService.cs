using Admin.Shared.Response;

namespace Admin.Application.Interfaces;

public interface IHostModelService
{
    Task<IEnumerable<ModelResponse>> GetModel();
}
