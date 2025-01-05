
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using AutoMapper;

namespace Admin.Application.Services;

public class TelnetService : ITelnetService
{
    private readonly ITelnetRepository _repository;
    private readonly IHostRepository _hostRepository;
    private readonly IMapper _mapper;
    public TelnetService(ITelnetRepository repository, IMapper mapper, IHostRepository hostRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _hostRepository = hostRepository;
    }
}
