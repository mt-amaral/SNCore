using ConnectionControl.Application.Dtos;


namespace ConnectionControl.Application.Interfaces;

public interface IHardwareService
{
    Task<HardwareDto> SelectByPk(int id);
    Task<IEnumerable<HardwareDto>> SelectAll();
    Task Create(HardwareDto hardwareDTC);
    Task Edit(HardwareDto hardwareDTC);
    Task Delete(int hardwareId);
    Task TesteSNPM();
}
