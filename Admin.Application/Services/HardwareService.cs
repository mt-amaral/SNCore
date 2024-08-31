using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Payload;
using Admin.Shared.Response;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Admin.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IValidator<HardwarePayload> _validatorPayload;
    private readonly IHardwareRepository _repository;
    private readonly IMapper _mapper;
    public HardwareService(IHardwareRepository repository,
        IMapper mapper,
        IValidator<HardwarePayload> validatorPayload,
        ISnmpRepository snmpRepository,
        ITelnetRepository telnetRepository)
    {
        _validatorPayload = validatorPayload;
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<IEnumerable<HardwareResponse>> SelectAll()
    {
        var entityList = await _repository.SelectAll();
        return _mapper.Map<IEnumerable<HardwareResponse>>(entityList);
    }

    public async Task<HardwareResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByPk(id);
        return _mapper.Map<HardwareResponse>(entity);
    }

    public async Task Create(HardwarePayload request)
    {
        var entity = _mapper.Map<Hardware>(request);

        await _repository.Create(entity);
    }

    public async Task Edit(int Id, HardwarePayload request)
    {
        var entity = await _repository.SelectByPk(Id);
        _mapper.Map(request, entity);
        await _repository.Edit(entity);
    }

    public async Task EditPartial(int Id, JsonPatchDocument<HardwarePayload> request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entityForUpdate = _mapper.Map<HardwarePayload>(entityDb);
        request.ApplyTo(entityForUpdate);

        var validationResult = await _validatorPayload.ValidateAsync(entityForUpdate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        _mapper.Map(entityForUpdate, entityDb);
        await _repository.Edit(entityDb);
    }

    public async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }
}
