using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;

namespace Admin.Persistence.Repositories;

public class HostGroupRepository : BaseRepository<HostGroup>, IHostGroupRepository
{

    public HostGroupRepository(ApplicationDbContext context) : base(context)
    {

    }

}
