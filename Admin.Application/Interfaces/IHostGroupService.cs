using Admin.Shared.Payload;


namespace Admin.Application.Interfaces;

public interface IHostGroupService
{
    Task<IEnumerable<HostGroupPayload>> SelectAll();
}
