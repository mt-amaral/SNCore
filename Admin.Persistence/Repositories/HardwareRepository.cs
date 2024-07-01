﻿using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;

namespace Admin.Persistence.Repositories
{
    public class HardwareRepository : RepositoryBase<Hardware>, IHardwareRepository
    {
        public HardwareRepository(ApplicationDbContext context) : base(context)
        {
        }

    }
}
