using Admin.Shared.Payload;
using Admin.Shared.Request;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwareRequest hardwareCreate);
    Task Edit(int id, HardwareRequest request);
    Task Delete(int hardwareId);
}
