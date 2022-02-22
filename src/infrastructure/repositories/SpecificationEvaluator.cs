using Delicious.core;
using Microsoft.EntityFrameworkCore;

namespace Delicious.infrastructure
{
    public class SpecificationEvaluator<TEntity> where TEntity : BaseEntity
    {
        public static IQueryable<TEntity> getQuery(IQueryable<TEntity> inputQuery, ISpecification<TEntity> spec)
        {
            var query = inputQuery;

            if (spec.Criteria != null)
            {
                query = query.Where(spec.Criteria);
            }
            
            if (!spec.asNoTracking)
            {
                query = query.AsNoTracking();
            }

            if (spec.OrderBy != null)
            {
                query = query.OrderBy(spec.OrderBy);
            }
            else if (spec.OrderByDescending != null)
            {
                query = query.OrderByDescending(spec.OrderByDescending);
            }

            if (spec.GroupBy != null)
            {
                query = query.GroupBy(spec.GroupBy).SelectMany(x => x);
            }

            query = spec.Includes.Aggregate(query,
                                    (current, include) => current.Include(include));


            query = spec.IncludeStrings.Aggregate(query,
                                    (current, include) => current.Include(include));

            return query;
        }
    }
}