using Admin.Domain.Entities;
using Admin.Domain.Interfaces;
using Admin.Persistence.Context;
using Microsoft.EntityFrameworkCore;


namespace Admin.Persistence.Repositories;

public class HardwareRepositories : IHardwareRepositories
{
    private readonly  ApplicationDbContext _context;

    public HardwareRepositories(ApplicationDbContext context)
    {
        _context = context;
    }

    public async Task<bool> SaveAllAsync()
    {
        return await _context.SaveChangesAsync() > 0;
    }

    public async Task<Hardware> SelectByPk(int? id)
    {
        var hadware = await _context.Hardware.Where(x => x.Id == id).FirstOrDefaultAsync();
        if (hadware == null) 
        {
            throw new InvalidOperationException();
        }
        return hadware;
    }

    public async Task<IEnumerable<Hardware>> SelectAll()
    {
        return await _context.Hardware.ToListAsync();
    }
}


