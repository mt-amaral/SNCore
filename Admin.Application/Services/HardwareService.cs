using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Response;
using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;

namespace Admin.Application.Services;

public class HardwareService : IHardwareService
{
    private readonly IHardwareRepository _repository;
    private readonly IMapper _mapper;
    public HardwareService(IHardwareRepository repository, IMapper mapper)
    {
        _repository = repository;
        _mapper = mapper;
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
    }

    public virtual async Task Edit(int Id, HardwareBase request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entity = _mapper.Map<Hardware>(request);
        await _repository.Edit(entity);
    }

    public virtual async Task EditPartial(int Id, JsonPatchDocument<HardwareBase> request)
    {
        var entityDb  = await _repository.SelectByPk(Id);
        var entityForUpdate = _mapper.Map<HardwareBase>(entityDb);
        request.ApplyTo(entityForUpdate);
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
