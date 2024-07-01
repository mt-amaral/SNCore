using Admin.Share.Response;
using Admin.Share.Request;
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class HardwareService : BaseService<Hardware, HardwareRequest, HardwareResponse, IHardwareRepository>, IHardwareService
{
    public HardwareService(IHardwareRepository hardwareRepository, IMapper mapper)
        : base(hardwareRepository, mapper)
    {
    }
}
