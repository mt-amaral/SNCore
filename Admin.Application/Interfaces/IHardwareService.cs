using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;
using Microsoft.AspNetCore.JsonPatch;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwarePayload hardwareCreate);
    Task CreateFull(CreateHardwareFull hardwareCreate);
    Task Edit(int Id, HardwarePayload hardwareEdit);
    Task EditPartial(int Id, JsonPatchDocument<HardwarePayload> request);
    Task Delete(int hardwareId);
}
