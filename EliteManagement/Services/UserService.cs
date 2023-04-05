using EliteManagement.Contexts;
using EliteManagement.Models.Entities;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace EliteManagement.Services;

internal class UserService : GenericService<UserEntity>
{
    private readonly DataContext _context = new DataContext();

    public async Task<UserEntity> CreateAsync(UserEntity entity)
    {
        var _entity = await _context.Users.FirstOrDefaultAsync(x => x.Email == entity.Email);
        if (_entity == null)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        return _entity;
    }

    public override async Task<IEnumerable<UserEntity>> GetAllAsync()
    {
        return await _context.Users.Include(x => x.Id).Include(x => x.Email).ToListAsync();
    }

    public override async Task<UserEntity> GetAsync(Expression<Func<UserEntity, bool>> predicate)
    {
        var item = await _context.Users.Include(x => x.Id).Include(x => x.Email).FirstOrDefaultAsync(predicate, CancellationToken.None);
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
