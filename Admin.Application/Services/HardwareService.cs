using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class HardwareService : BaseService<Hardware, HardwareRequest, HardwareResponse, IHardwareRepository>, IHardwareService
{
    public HardwareService(IHardwareRepository hardwareRepository, IMapper mapper)
        : base(hardwareRepository, mapper)
    {
    }
}
