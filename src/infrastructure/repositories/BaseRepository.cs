using System.Linq.Expressions;
using Delicious.core;
using Microsoft.EntityFrameworkCore;

namespace Delicious.infrastructure
{
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : BaseEntity
    {
        private readonly DeliciousFoodDbContext _context;

        public BaseRepository(DeliciousFoodDbContext context)
        {
            _context = context;
        }

        public async Task<TEntity> findSingleOrDefaultAsync(ISpecification<TEntity> spec)
        {
            var entity = await ApplySpecification(spec).SingleOrDefaultAsync();
            return entity!;
        }


        public async Task<IEnumerable<TEntity>> listAsync(ISpecification<TEntity> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }


        public void add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Edit(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
        }


        public void Remove(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
        }



        private IQueryable<TEntity> ApplySpecification(ISpecification<TEntity> spec)
        {
            return SpecificationEvaluator<TEntity>.getQuery(_context.Set<TEntity>().AsQueryable(), spec);
        }
    }
}