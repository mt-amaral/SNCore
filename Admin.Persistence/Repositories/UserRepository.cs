
using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Admin.Persistence.Repositories.Base;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class UserRepository: IUserRepository
{
    private readonly ApplicationDbContext _context;
    private readonly DbSet<User> _dbSet;
    public UserRepository(ApplicationDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<User>();
        
    }
    private async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task Create(User entity)
    {
        await _dbSet.AddAsync(entity);
        await SaveAllAsync();
    }
}
