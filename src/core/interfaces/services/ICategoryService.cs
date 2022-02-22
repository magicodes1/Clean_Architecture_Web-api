namespace Delicious.core
{
    public interface ICategoryService : IService<Category>
    {
        Task<Category> findById(int id);
        Task<Category> getCategoryByName(string name);

        Task<IEnumerable<Category>> list();
    }
}