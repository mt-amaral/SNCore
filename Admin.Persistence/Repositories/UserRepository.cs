
using Admin.Domain.Account;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;

namespace Admin.Persistence.Repositories;

public class UserRepository : IUserRepository
{


    private readonly UserDbContext _context;
    private readonly DbSet<User> _dbSet;

    public UserRepository(UserDbContext context)
    {
        _context = context;
        _dbSet = _context.Set<User>();
    }


    public async Task<IEnumerable<User>> GetAll()
    {
        return await _dbSet
            .AsNoTracking().ToListAsync();
    }

}
