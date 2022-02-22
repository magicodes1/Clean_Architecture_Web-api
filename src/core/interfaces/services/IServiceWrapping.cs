namespace Delicious.core
{
    public interface IServiceWrapping
    {
        IProductService productService { get;}
        ICategoryService categoryService { get;}
    }
}