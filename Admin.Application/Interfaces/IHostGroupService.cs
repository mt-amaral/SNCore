using Admin.Shared.Payload;


namespace Admin.Application.Interfaces;

public interface IHostGroupService
{
    Task<ICollection<HostGroupPayload>> SelectAll();
}
