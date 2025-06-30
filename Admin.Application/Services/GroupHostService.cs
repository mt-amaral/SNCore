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

public class GroupHostService : IGroupHostService
{

    private readonly IHostRepository _repository;
    private readonly IHostGroupRepository _groupRepository;
    private readonly IMapper _mapper;
    
    public GroupHostService(IMapper mapper, IHostRepository repository, IHostGroupRepository groupRepository)
    {
        _repository = repository;
        _groupRepository = groupRepository;
        _mapper = mapper;
    }



    public async Task<Response<GroupHostResponse?>> CreateHostGroup(CreateGroupHostRequest request)
    {
        try
        {
            var entity = _mapper.Map<HostGroup>(request);
            await _groupRepository.CreateGroup(entity);
            var response = _mapper.Map<GroupHostResponse>(entity);
            var result = new Response<GroupHostResponse?>(response, 204, $"Host {request.GroupName} criado com sucesso.");
            return result;
        }
        catch
        {
            throw new Exception($"Erro ao Criar Grup {request.GroupName}");
        }
    }

    public async Task<Response<GroupHostResponse?>> UpdateHostGroup(CreateGroupHostRequest request, int id)
    {
        try
        {
            var entity = await _groupRepository.SelectByGrup(id);
            if (entity is null)
                return new Response<GroupHostResponse?>(null, 404, $"Grup Id {id} não encontrado.");
            
            _mapper.Map(request, entity);
            await _groupRepository.UpdateGroup(entity);
            var response = _mapper.Map<GroupHostResponse?>(entity);
            return new Response<GroupHostResponse?>(response, 201, $"Grupo {request.GroupName} atualizado com sucesso.");
        }
        catch
        {
            throw new Exception($"Erro ao Editar Grupo {request.GroupName}");
        }
    }

    public async Task<Response<GroupHostResponse?>> DeleteHostGroup(List<int> listId)
    {
        try
        {
            var entity = await _groupRepository.FilteredGroup(new GroupHostFilter(){Ids = listId});
            var list = entity.ToList();
            if (list.Any())
            {
                await _groupRepository.DeleteGroupRange(list);
                return new Response<GroupHostResponse?>(null, 201, $"Grupo  deletado.");
            }
            else
                return new Response<GroupHostResponse?>(null, 404, $"Grupo não encontrado.");
        }
        catch 
        {
            throw new Exception($"Erro ao Deletar Grupo");
        }
    }

    public async Task<Response<List<GroupHostResponse?>>> GetHostGroupList(GroupHostFilter filter)
    {
        var entity = await _groupRepository.FilteredGroup(filter);
        var response = _mapper.Map<List<GroupHostResponse?>>(entity);
        return new Response<List<GroupHostResponse?>> (response, 200, null);
    }

    public async Task<Response<Dictionary<int, string>?>> GroupAddHostList(int idGroup, List<int> hostIds)
    {
        var responseDictionary = new Dictionary<int, string>();
        var hostsUpdate = new List<Host>();
        
        var entity = await _groupRepository.SelectByGrup(idGroup);
        if (entity is null)
            return new Response<Dictionary<int, string>?>(null, 404, $"Grupo Id {idGroup} não encontrado.");
        try
        {
            var hosts = await _repository.Query(h => hostIds.Contains(h.Id));
            foreach (var hostId in hostIds)
            {
                var host  = hosts.FirstOrDefault(h => h.Id == hostId);
                if (host is null)
                {
                    responseDictionary.Add(hostId, $"Host Id {hostId} não encontrado.");
                    continue;
                }
            
                if (host.GroupId == idGroup)
                {
                    host.UpdateGruopId(null);
                    hostsUpdate.Add(host);
                    responseDictionary.Add(hostId, $"Host Id {hostId} removido do Grupo Id {idGroup}.");
                }
                else
                {
                    host.UpdateGruopId(idGroup);
                    hostsUpdate.Add(host);
                    responseDictionary.Add(hostId, $"Host Id {hostId} adicionado ao Grupo Id {idGroup}.");
                }

            }
            await _repository.UpdateRange(hostsUpdate);
            return new Response<Dictionary<int, string>?>(responseDictionary, 201, "Operação concluída."); 
        }
        catch
        {
            throw new Exception($"Erro ao Editar Grupo Id {entity.GroupName}");
        }
       
    }
    
}
