namespace Delicious.core
{
    public interface IProductService : IService<Product>
    {
        Task<Product> findByShortName(string name);
          public Task<IEnumerable<Product>> list();
    }
}