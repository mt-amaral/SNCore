
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Response;
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
    public async Task<IEnumerable<TelnetResponse>> SelectAll()
    {
        var entityList = await _repository.SelectAll();
        return _mapper.Map<IEnumerable<TelnetResponse>>(entityList);
    }

    public async Task<TelnetResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByPk(id);
        return _mapper.Map<TelnetResponse>(entity);
    }

    public async Task Create(int HardwareId, TelnetPayload request)
    {
        await _hardwareRepository.SelectByPk(HardwareId);
        var entity = _mapper.Map<Telnet>(request);
        entity.SetHardwareId(HardwareId);
        await _repository.Create(entity);
    }

    public async Task Edit(int Id, TelnetPayload request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entity = _mapper.Map<Telnet>(request);
        await _repository.Edit(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }
    public async Task<TelnetResponse> SelectByHardwareId(int id)
    {
        var telnet = await _repository.SelectByHardwareId(id);
        return _mapper.Map<TelnetResponse>(telnet);
    }
}
