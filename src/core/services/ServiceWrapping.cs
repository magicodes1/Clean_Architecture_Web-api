using System.Collections;

namespace Delicious.core
{
    public class ServiceWrapping : IServiceWrapping
    {
        private readonly IUnitofWork _unitOfWork;

        private IProductService _productService = null!;
        private ICategoryService _categoryService = null!;

        public ServiceWrapping(IUnitofWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IProductService productService => _productService ??= new ProductService(_unitOfWork);

        public ICategoryService categoryService => _categoryService ??= new CategoryService(_unitOfWork);
    }
}