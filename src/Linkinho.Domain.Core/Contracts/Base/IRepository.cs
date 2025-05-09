using Linkinho.Domain.Core.Base;
using System.Linq.Expressions;

namespace Linkinho.Domain.Core.Contracts.Base;

public interface IRepository<IEntity> where IEntity : Entity
{
    Task<IList<IEntity>> GetAll(Expression<Func<IEntity, bool>> predicate = null);
    Task<IEntity> Get(int id);
    Task<IEntity> Get(Expression<Func<IEntity, bool>> predicate);
    Task<IEntity> Create(IEntity entity);
    Task<IEntity> Update(IEntity entity);
    Task<bool> Delete(int id);
    Task<bool> Exist(int id);
}
