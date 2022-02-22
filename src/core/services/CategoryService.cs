namespace Delicious.core
{
    public sealed class CategoryService : BaseService<Category>,ICategoryService
    {
        private readonly IUnitofWork _unitOfWork;

        public CategoryService(IUnitofWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Category> findById(int id)
        {
            var category = await _unitOfWork.Repository<Category>()
                            .findSingleOrDefaultAsync(new FIndCategoryWithConditionSpecification(id));
            return category; 
        }

        public async Task<Category> getCategoryByName(string name)
        {
            var category = await _unitOfWork.Repository<Category>()
                            .findSingleOrDefaultAsync(new FIndCategoryWithConditionSpecification(name));
            return category;
        }

        public async Task<IEnumerable<Category>> list()
        {
            var categories = await _unitOfWork.Repository<Category>().listAsync(new GetCategoriesWithNoTracking());
            return categories;
        }
    }
}