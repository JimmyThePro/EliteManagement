using EliteManagement.Contexts;
using EliteManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteManagement.Services;

internal class CaseService : GenericService<CaseEntity>
{
    private readonly DataContext _context = new DataContext();

    public async Task CreateAsync(CaseEntity entity)
    {
        await _context.AddAsync(entity);
        await _context.SaveChangesAsync();
    }

    public override async Task<IEnumerable<CaseEntity>> GetAllAsync()
    {
        return await _context.Cases.Include(x => x.User).Include(x => x.Id).ToListAsync();
    }

    public override async Task<CaseEntity> GetAsync(Expression<Func<CaseEntity, bool>> predicate)
    {
        var item = await _context.Cases
            .Include(x => x.User)
            .Include(x => x.User).ThenInclude(x => x.Id)
            .Include(x => x.User).ThenInclude(x => x.Email)
            .Include(x => x.Comments)
            .FirstOrDefaultAsync(predicate);
        if (item != null)
        {
            return item;
        }
        return null!;
    }
}
