using System.Linq.Expressions;

namespace Delicious.core
{
    public interface IUnitofWork : IDisposable
    {
        IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity;
        Task completed();
    }
}