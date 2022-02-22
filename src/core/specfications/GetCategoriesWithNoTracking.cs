namespace Delicious.core
{
    public class GetCategoriesWithNoTracking : BaseSpecification<Category>
    {
        public GetCategoriesWithNoTracking() : base()
        {
            AsNoTracking(false);
            AddInclude(x => x.Products);
            ApplyOrderByDescending(x => x.Id);
        }
    }
}