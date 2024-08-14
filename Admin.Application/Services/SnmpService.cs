
using Admin.Application.Interfaces;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Base;
using Admin.Shared.Response;
using AutoMapper;

namespace Admin.Application.Services;

public class SnmpService : ISnmpService
{
    private readonly ISnmpRepository _repository;
    private readonly IMapper _mapper;
    public SnmpService(ISnmpRepository snmpRepository, IMapper mapper)
    {
        _repository = snmpRepository;
        _mapper = mapper;
    }
    public virtual async Task<IEnumerable<SnmpResponse>> SelectAll()
    {
        var entityList = await _repository.SelectAll();
        return _mapper.Map<IEnumerable<SnmpResponse>>(entityList);
    }

    public virtual async Task<SnmpResponse> SelectByPk(int id)
    {
        var entity = await _repository.SelectByPk(id);
        return _mapper.Map<SnmpResponse>(entity);
    }

    public virtual async Task Create(SnmpBase request)
    {
        var entity = _mapper.Map<Snmp>(request);
        await _repository.Create(entity);
    }

    public virtual async Task Edit(int Id, SnmpBase request)
    {
        var entityDb = await _repository.SelectByPk(Id);
        var entity = _mapper.Map<Snmp>(request);
        await _repository.Edit(entity);
    }

    public virtual async Task Delete(int id)
    {
        var entity = await _repository.SelectByPk(id);
        if (entity != null)
            await _repository.Delete(entity);

    }

    public async Task<SnmpResponse> SelectByHardwareId(int id)
    {
        var snmp = await _repository.SelectByHardwareId(id);
        return _mapper.Map<SnmpResponse>(snmp);
    }
}
