

namespace Delicious.core
{
    public class FIndCategoryWithConditionSpecification : BaseSpecification<Category>
    {
        public FIndCategoryWithConditionSpecification(int id) : base(x=>x.Id==id)
        {
            AsNoTracking(false);
            ApplyOrderByDescending(x=>x.Id);

        }

        public FIndCategoryWithConditionSpecification(string name) : base(x=>x.CategoryName==name)
        {
            AsNoTracking(false);
            ApplyOrderByDescending(x=>x.CategoryName);
        }
    }
}