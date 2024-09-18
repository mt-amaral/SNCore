
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
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
    public async Task<TelnetPayload> SelectByHostId(int id)
    {
        var telnet = await _repository.SelectByHostId(id);
        return _mapper.Map<TelnetPayload>(telnet);
    }
}
