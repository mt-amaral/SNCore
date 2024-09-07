using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;

namespace Admin.Persistence.Repositories
{
    public class HardwareRepository : BaseRepository<Hardware>, IHardwareRepository
    {
        private readonly ApplicationDbContext _context;
        public HardwareRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

    }
}
