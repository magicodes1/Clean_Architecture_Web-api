namespace Delicious.core
{
    public interface IService<Entity> where Entity : BaseEntity
    {
        Task<Response> add(Entity entity);
        Task<Response> Edit(Entity entity);
        Task<Response> Remove(Entity entity);
    }
}