
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : ISnmpService
{
    private readonly ISnmpRepository _repository;
    private readonly IHostRepository _hostRepository;
    private readonly IMapper _mapper;
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper,
        IHostRepository hostRepository)
    {
        _repository = snmpRepository;
        _hostRepository = hostRepository;
        _mapper = mapper;
    }

}
