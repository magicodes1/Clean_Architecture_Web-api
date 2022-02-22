using System.Collections;
using Delicious.core;

namespace Delicious.infrastructure
{
    public class UnitofWork : IUnitofWork
    {
        private readonly DeliciousFoodDbContext _context;

        private Hashtable _repositories = null!;


        public UnitofWork(DeliciousFoodDbContext context)
        {
            _context = context;
        }
        public async Task completed() =>  await _context.SaveChangesAsync();

        public void Dispose()
        {
            _context.Dispose();
        }

        public IRepository<TEntity> Repository<TEntity>() where TEntity : BaseEntity
        {
           if (_repositories == null)
                _repositories = new Hashtable();

            var type = typeof(TEntity).Name;

            if (!_repositories.ContainsKey(type))
            {
                var repositoryType = typeof(BaseRepository<>);

                var repositoryInstance =
                    Activator.CreateInstance(repositoryType
                        .MakeGenericType(typeof(TEntity)), _context);

                _repositories.Add(type, repositoryInstance);
            }

            return (IRepository<TEntity>) _repositories[type]!;
        }
    }
}