

using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IHardwareRepositories _hardwareRepositories;
    private readonly IMapper _mapper;
    public HardwareService(IHardwareRepositories hardwareRepositories, IMapper mapper)
    {
        _mapper = mapper;
        _hardwareRepositories = hardwareRepositories; 
    }

    public async Task<IEnumerable<HardwareResponse>> SelectAll()
    {
       var hardwareList = await _hardwareRepositories.SelectAll();
        return _mapper.Map<IEnumerable<HardwareResponse>>(hardwareList);
    }

    public async Task<HardwareResponse> SelectByPk(int id)
    {
        var hardware = await _hardwareRepositories.SelectByPk(id);
        return _mapper.Map<HardwareResponse>(hardware);
    }
    public async Task Edit(HardwareRequest hardwareRequest)
    {
        var hardware = _mapper.Map<Hardware>(hardwareRequest);
       await _hardwareRepositories.Edit(hardware);
    }
    public async Task Delete(HardwareRequest hardwareRequest)
    {
        var hardware = _mapper.Map<Hardware>(hardwareRequest);
        await _hardwareRepositories.Delete(hardware);
    }
}
