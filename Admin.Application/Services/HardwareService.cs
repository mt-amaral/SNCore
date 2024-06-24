

using Admin.Application.DTOs;
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

    public async Task<IEnumerable<HardwareDTO>> SelectAll()
    {
       var hardwareList = await _hardwareRepositories.SelectAll();
        return _mapper.Map<IEnumerable<HardwareDTO>>(hardwareList);
    }

    public async Task<HardwareDTO> SelectByPk(int id)
    {
        var hardware = await _hardwareRepositories.SelectByPk(id);
        return _mapper.Map<HardwareDTO>(hardware);
    }
    public async Task Edit(HardwareDTO hardwareDTO)
    {
        var hardware = _mapper.Map<Hardware>(hardwareDTO);
       await _hardwareRepositories.Edit(hardware);
    }
}
