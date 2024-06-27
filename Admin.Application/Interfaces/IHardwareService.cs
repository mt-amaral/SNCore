using Admin.Share.Response;
using Admin.Share.Request;


namespace Admin.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareResponse> SelectByPk(int id);
    Task<IEnumerable<HardwareResponse>> SelectAll();
    Task Edit(HardwareRequest hardwareRequest);
    Task Delete(HardwareRequest hardwareRequest);
}
