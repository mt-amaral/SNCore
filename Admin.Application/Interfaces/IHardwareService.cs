using Admin.Shared.Base;
using Admin.Shared.Response;
using Microsoft.AspNetCore.JsonPatch;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwareBase hardwareCreate);
    Task Edit(int Id, HardwareBase hardwareEdit);
    Task EditPartial(int Id, JsonPatchDocument<HardwareBase> request);
    Task Delete(int hardwareId);
}
