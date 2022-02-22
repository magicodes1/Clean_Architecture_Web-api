

namespace Delicious.core
{
    public sealed class ProductService : BaseService<Product>, IProductService
    {
        private readonly IUnitofWork _unitOfWork;

        public ProductService(IUnitofWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Product> findByShortName(string name)
        {
            var product = await _unitOfWork.Repository<Product>().findSingleOrDefaultAsync(new FindProductWithConditionSpecification(name));
            return product;
        }

        public async Task<IEnumerable<Product>> list()
        {
            var products = await _unitOfWork.Repository<Product>().listAsync(new GetProductsWithNoTracking());
            return products;
        }
    }
}