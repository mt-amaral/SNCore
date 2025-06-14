using System.Linq.Expressions;
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Shared.Interfaces;
using Admin.Shared.Request.Expression;
using Admin.Shared.Request.Host;
using Admin.Shared.Response;
using Admin.Shared.Response.Expression;
using Admin.Shared.Response.Host;
using AutoMapper;

namespace Admin.Application.Services;

public class HostService : IHostService
{

    private readonly IHostRepository _repository;
    private readonly IMapper _mapper;
    
    public HostService(IMapper mapper, IHostRepository repository)
    {
        _repository = repository;
        _mapper = mapper;
    }

    public async Task<Response<HostResponse?>> CreateHost(CreateHostRequest request)
    {
        try
        {
            var entity = _mapper.Map<Host>(request);
            await _repository.CreateHost(entity);
            var response = _mapper.Map<HostResponse>(entity);
            return new Response<HostResponse?>(response, 200, $"Host {request.Name} criado com sucesso.");
        }
        catch
        {
            throw new Exception($"Erro ao Criar Host {request.Name}");
        }
    }
    
    public async Task<Response<HostResponse?>> UpdateHost(CreateHostRequest request, int id)
    {
        try
        {
            var entity = await _repository.SelectByHost(id);
            if (entity is null)
                return new Response<HostResponse?>(null, 404, $"HostId {request.Name} não encontrado.");
            
            _mapper.Map(request, entity);
            await _repository.UpdateHost(entity);
            return new Response<HostResponse?>(null, 204, $"Host {request.Name} atualizado com sucesso.");
        }
        catch
        {
            throw new Exception($"Erro ao Editar Host {request.Name}");
        }
    }

    public async Task<Response<HostResponse?>> DeleteHost(int id)
    {
        try
        {
            var entity = await _repository.SelectByHost(id);
            if (entity is null)
                return new Response<HostResponse?>(null, 404, $"HostId {id} não encontrado.");
            await _repository.DeleteHost(entity);
            
            return new Response<HostResponse?>(null, 201, $"HostId {id} deletado com sucesso.");
        }
        catch 
        {
            throw new Exception($"Erro ao Deletar Host {id}");
        }
    }

    public async Task<Response<HostResponse?>> GetHost(int id)
    {
        var entity = await _repository.SelectByHost(id);
        if (entity is null)
            return new Response<HostResponse?>(null, 404, $"HostId {id} não encontrado.");
        
        var response = _mapper.Map<HostResponse>(entity);
        return new Response<HostResponse?>(response, 200, null);
    }
    
    public async Task<Response<List<HostResponse?>>> GetHostList(int pageNumber = 1,int pageSize = 20)
    {
        var entity = await _repository.FilteredHost(pageNumber, pageSize!);
        var response = _mapper.Map<List<HostResponse?>>(entity);
        return new Response<List<HostResponse?>> (response, 200, null);
    }
    
}
