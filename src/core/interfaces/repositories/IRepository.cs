using System.Linq.Expressions;

namespace Delicious.core
{
    public interface IRepository<TEntity> where TEntity : BaseEntity
    {
        Task<IEnumerable<TEntity>> listAsync(ISpecification<TEntity> spec);

        Task<TEntity> findSingleOrDefaultAsync(ISpecification<TEntity> spec);

        void add(TEntity entity);
        void Edit(TEntity entity);
        void Remove(TEntity entity);
    }
}