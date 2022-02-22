using System.Linq.Expressions;

namespace Delicious.core
{
    public class BaseSpecification<TEntity> : ISpecification<TEntity> where TEntity : BaseEntity
    {
        protected BaseSpecification(Expression<Func<TEntity, bool>> criteria)
        {
            Criteria = criteria;
        }
        protected BaseSpecification()
        {

        }

        public Expression<Func<TEntity, bool>> Criteria { get; } = null!;
        public List<Expression<Func<TEntity, object>>> Includes { get; } = new List<Expression<Func<TEntity, object>>>();
        public List<string> IncludeStrings { get; } = new List<string>();
        public Expression<Func<TEntity, object>> OrderBy { get; private set; } = null!;
        public Expression<Func<TEntity, object>> OrderByDescending { get; private set; } = null!;
        public Expression<Func<TEntity, object>> GroupBy { get; private set; } = null!;

        public bool asNoTracking { get; private set; } = true;

        protected virtual void AddInclude(Expression<Func<TEntity, object>> includeExpression)
        {
            Includes.Add(includeExpression);
        }

        protected virtual void AddInclude(string includeString)
        {
            IncludeStrings.Add(includeString);
        }

        protected virtual void ApplyOrderBy(Expression<Func<TEntity, object>> orderByExpression)
        {
            OrderBy = orderByExpression;
        }

        protected virtual void ApplyOrderByDescending(Expression<Func<TEntity, object>> orderByDescendingExpression)
        {
            OrderByDescending = orderByDescendingExpression;
        }

        protected virtual void ApplyGroupBy(Expression<Func<TEntity, object>> groupByExpression)
        {
            GroupBy = groupByExpression;
        }

        protected virtual void AsNoTracking(bool isTrack = true)
        {
            asNoTracking = isTrack;
        }
    }
}