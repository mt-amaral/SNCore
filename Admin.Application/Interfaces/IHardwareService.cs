using Admin.Shared.Base;
using Admin.Shared.Full;
using Admin.Shared.Response;
using Microsoft.AspNetCore.JsonPatch;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwareBase hardwareCreate);
    Task CreateFull(HardwareFull hardwareCreate);
    Task Edit(int Id, HardwareBase hardwareEdit);
    Task EditFull(int Id, HardwareFull hardwareEdit);
    Task EditPartial(int Id, JsonPatchDocument<HardwareBase> request);
    Task Delete(int hardwareId);
}
