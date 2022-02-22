using AutoMapper;
using Delicious.core;
using Microsoft.AspNetCore.Mvc;

namespace Delicious.webapi
{
    [ApiController]
    [Route("api/{Controller}")]
    public class ProductController : ControllerBase
    {
        private readonly IServiceWrapping _serviceWrapping;
        private readonly IMapper _mapper;
        public ProductController(IServiceWrapping serviceWrapping, IMapper mapper)
        {
            _serviceWrapping = serviceWrapping;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {
            var products = await _serviceWrapping.productService.list();
            if (products == null) return BadRequest();
            return Ok(products);
        }


        // [HttpGet("{id}")]
        // public async Task<IActionResult> getById(int id)
        // {
        //     var product = await _serviceWrapping.ProductService.findById(id);

        //     return Ok(product);
        // }

        [HttpGet("{urlname}")]
        public async Task<IActionResult> getByUrlName(string urlname)
        {
            var product = await _serviceWrapping.productService.findByShortName(urlname);
            if (product == null) return BadRequest();
            return Ok(product);
        }


        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> add(Product product)
        {
            var result = await _serviceWrapping.productService.add(product);

            if (!result.Status)
            {
                return BadRequest(result.Error);
            }

            return CreatedAtAction(nameof(getByUrlName),new {urlname=product.UrlShortName},product);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> edit(int id, ProductDTO product)
        {
            var pro = _mapper.Map<Product>(product);

            var result = await _serviceWrapping.productService.Edit(pro);

            if (!result.Status)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> remove(int id, ProductDTO product)
        {
            var pro = _mapper.Map<Product>(product);

            var result = await _serviceWrapping.productService.Remove(pro);

            if (!result.Status)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}