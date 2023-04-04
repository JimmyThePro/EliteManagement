using EliteManagement.Contexts;
using EliteManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteManagement.Services;

internal class UserService : GenericService<UserEntity>
{
    private readonly DataContext _context = new DataContext();

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.Include(x => x.Address).Include(x => x.UserType).ToListAsync();
    }

    public override async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var item = await _context.Users.Include(x => x.Address).Include(x => x.UserType).FirstOrDefaultAsync(predicate, CancellationToken.None);
        if (item != null)
        {
            return item;
        }
        return null!;
    }

    public override Task<UserEntity> SaveAsync(UserEntity entity, Expression<Func<UserEntity, bool>> predicate)
    {
        return base.SaveAsync(entity, predicate);
    }
}
