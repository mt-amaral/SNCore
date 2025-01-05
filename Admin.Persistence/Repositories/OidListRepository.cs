﻿
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class OidListRepository(ApplicationDbContext context) : IOidListRepository
{
    private readonly ApplicationDbContext _context = context;
    private readonly DbSet<Host> _dbSet = context.Set<Host>();

}
