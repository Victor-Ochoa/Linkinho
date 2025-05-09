using Linkinho.Domain.Core.Base;
using Linkinho.Domain.Core.Contracts;
using Linkinho.Infra.Repos.Data;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace Linkinho.Infra.Repos.Repositories;

public class BaseRepository<IEntity>(LinkinhoDbContext dbContext) : IRepository<IEntity> where IEntity : Entity
{
    private readonly LinkinhoDbContext _dbContext = dbContext;

    public async Task<IEntity> Create(IEntity entity)
    {
        await _dbContext.Set<IEntity>().AddAsync(entity);

        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Delete(Guid id)
    {
        var entity = await _dbContext.Set<IEntity>().FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        if (entity == null) return false;

        entity.IsDeleted = true;

        await _dbContext.SaveChangesAsync();

        return true;
    }

    public async Task<IEntity> Get(Guid id) => await _dbContext.Set<IEntity>().FindAsync(id);

    public async Task<IEntity> Get(Expression<Func<IEntity, bool>> predicate) => await _dbContext.Set<IEntity>().FirstOrDefaultAsync(predicate);

    public async Task<IList<IEntity>> GetAll(Expression<Func<IEntity, bool>> predicate = null) => predicate == null
            ? await _dbContext.Set<IEntity>().ToListAsync()
            : (IList<IEntity>)await _dbContext.Set<IEntity>().Where(predicate).ToListAsync();

    public async Task<IEntity> Update(IEntity entity)
    {
        dbContext.Set<IEntity>().Update(entity);

        await _dbContext.SaveChangesAsync();

        return entity;
    }

    public async Task<bool> Exist(Guid id) => await dbContext.Set<IEntity>().AnyAsync(e => e.Id == id);

}
