
using Admin.Application.Interfaces;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using AutoMapper;

namespace Admin.Application.Services;

public class TelnetService : ITelnetService
{
    private readonly ITelnetRepository _repository;
    private readonly IHardwareRepository _hardwareRepository;
    private readonly IMapper _mapper;
    public TelnetService(ITelnetRepository repository, IMapper mapper, IHardwareRepository hardwareRepository)
    {
        _repository = repository;
        _mapper = mapper;
        _hardwareRepository = hardwareRepository;
    }
    public async Task<TelnetPayload> SelectByHardwareId(int id)
    {
        var telnet = await _repository.SelectByHardwareId(id);
        return _mapper.Map<TelnetPayload>(telnet);
    }
}
