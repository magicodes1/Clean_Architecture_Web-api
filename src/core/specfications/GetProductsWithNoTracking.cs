namespace Delicious.core
{
    public class GetProductsWithNoTracking : BaseSpecification<Product>
    {
        public GetProductsWithNoTracking() : base(){
            AsNoTracking(false);
           // AddInclude(x=>x.Products);
           ApplyOrderByDescending(x=>x.Id);
        }
    }
}