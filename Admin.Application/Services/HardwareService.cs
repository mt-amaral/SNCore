﻿using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Request;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IHardwareRepository _repository;
    private readonly ISnmpRepository _snmpRepository;
    private readonly ITelnetRepository _telnetRepository;
    private readonly IMapper _mapper;
    IHardwareRepository Ref;
    public HardwareService(IHardwareRepository repository,
        IMapper mapper,
        ISnmpRepository snmpRepository,
        ITelnetRepository telnetRepository)
    {
        _telnetRepository = telnetRepository;
        _snmpRepository = snmpRepository;
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
        var entity = await _repository.SelectByHardware(id);
        return _mapper.Map<HardwareResponse>(entity);
    }

    public async Task Create(HardwareRequest request)
    {
        var entity = _mapper.Map<Hardware>(request);
        await _repository.Create(entity);
    }

    public async Task Edit(int id, HardwareRequest request)
    {
        var entity = await _repository.SelectByHardware(id);
        _mapper.Map(request, entity);
        await _repository.Edit(entity);
    }

    public async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }
}
