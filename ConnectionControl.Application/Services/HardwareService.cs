using ConnectionControl.Application.Dtos;
using Admin.Domain.Interfaces;
using Admin.Domain.Entities;
using ConnectionControl.Application.Interfaces;
using AutoMapper;
using ConnectionsControl.ConnectionLibrary.Interfaces;

namespace ConnectionControl.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IHardwareRepositories _hardwareRepositories;
    private readonly IDataConnection _dataConnection;
    private readonly IMapper _mapper;
    public HardwareService(IHardwareRepositories hardwareRepositories, IDataConnection dataConnection, IMapper mapper)
    {
        _dataConnection = dataConnection;
        _mapper = mapper;
        _hardwareRepositories = hardwareRepositories;
    }


    public async Task<IEnumerable<HardwareDto>> SelectAll()
    {
        var hardwareList = await _hardwareRepositories.SelectAll();
        return _mapper.Map<IEnumerable<HardwareDto>>(hardwareList);
    }
    public async Task Create(HardwareDto hardwareRequest)
    {
        var hardware = _mapper.Map<Hardware>(hardwareRequest);
        await _hardwareRepositories.Create(hardware);
    }

    public async Task<HardwareDto> SelectByPk(int id)
    {
        var hardware = await _hardwareRepositories.SelectByPk(id);
        return _mapper.Map<HardwareDto>(hardware);
    }
    public async Task Edit(HardwareDto hardwareRequest)
    {
        var hardware = _mapper.Map<Hardware>(hardwareRequest);
        await _hardwareRepositories.Edit(hardware);
    }
    public async Task Delete(int hardwareId)
    {
        var hardware = await _hardwareRepositories.SelectByPk(hardwareId);
        if (hardware != null)
        {
            await _hardwareRepositories.Delete(hardware);
        }
    }
    public async Task TesteSNPM()
    {
        var hardwareList = await _hardwareRepositories.SelectAll();

        foreach (var hardware in hardwareList)
        {
            _dataConnection.PerformSnmpOperation(hardware.Ipv4);
        }
        
    }
}
