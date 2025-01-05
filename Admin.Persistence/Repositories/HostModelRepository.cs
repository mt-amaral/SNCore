using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;


namespace Admin.Persistence.Repositories;

public class HostModelRepository : BaseRepository<HostModel>, IHostModelRepository
{

    public HostModelRepository(ApplicationDbContext context) : base(context)
    {

    }

}
