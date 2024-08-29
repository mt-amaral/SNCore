﻿using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Response;
using AutoMapper;
using FluentValidation;
using Microsoft.AspNetCore.JsonPatch;

namespace Admin.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IValidator<HardwareBase> _validatorBase;
    private readonly IValidator<SnmpBase> _validatorSnmp;
    private readonly IHardwareRepository _repository;
    private readonly ISnmpRepository _snmpRepository;
    private readonly IMapper _mapper;
    public HardwareService(IHardwareRepository repository, 
        IMapper mapper, 
        IValidator<HardwareBase> validatorBase, 
        IValidator<SnmpBase> validatorSnmp, 
        ISnmpRepository snmpRepository)
    {
        _validatorBase = validatorBase;
        _repository = repository;
        _mapper = mapper;
        _validatorSnmp = validatorSnmp;
        _snmpRepository = snmpRepository;
    }

    public virtual async Task<IEnumerable<HardwareResponse>> SelectAll()
    {
        var entityList = await _repository.SelectAll();
        return _mapper.Map<IEnumerable<HardwareResponse>>(entityList);
    }

    public virtual async Task<HardwareResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByPk(id);
        return _mapper.Map<HardwareResponse>(entity);
    }

    public virtual async Task Create(HardwareBase request)
    {
        var entity = _mapper.Map<Hardware>(request);
        await _repository.Create(entity);
/*        if (request.Snmp != null) 
        {
            var snmpEntity = _mapper.Map<Snmp>(request.Snmp);
            snmpEntity.SetHardwareId(entity.Id);
            await _snmpRepository.Create(snmpEntity);
        }*/
    }

    public virtual async Task Edit(int Id, HardwareBase request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entity = _mapper.Map<Hardware>(request);
        await _repository.Edit(entity);
    }

    public virtual async Task EditPartial(int Id, JsonPatchDocument<HardwareBase> request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entityForUpdate = _mapper.Map<HardwareBase>(entityDb);
        request.ApplyTo(entityForUpdate);

        var validationResult = await _validatorBase.ValidateAsync(entityForUpdate);
        if (!validationResult.IsValid)
            throw new ValidationException(validationResult.Errors);

        _mapper.Map(entityForUpdate, entityDb);
        await _repository.Edit(entityDb);
    }

    public virtual async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }
}
