using Admin.Shared.Base;
using Admin.Shared.Response;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Create(HardwareBase hardwareCreate);
    Task Edit(int Id, HardwareBase hardwareEdit);
    Task Delete(int hardwareId);
}
