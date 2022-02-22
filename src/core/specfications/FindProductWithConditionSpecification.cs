
namespace Delicious.core
{
    public class FindProductWithConditionSpecification : BaseSpecification<Product>
    {
        public FindProductWithConditionSpecification(int id) : base(x=>x.Id==id)
        {
            AsNoTracking(false);
            ApplyOrderByDescending(x=>x.Id);
            AddInclude(x=>x.Category);
        }

        public FindProductWithConditionSpecification(string urlName) : base(x=>x.UrlShortName==urlName)
        {
            AsNoTracking(false);
            ApplyOrderByDescending(x=>x.Id);
            AddInclude(x=>x.Category);
        }
    }
}