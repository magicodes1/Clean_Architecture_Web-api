using AutoMapper;
using Delicious.core;
using Microsoft.AspNetCore.Mvc;

namespace Delicious.webapi
{
    [ApiController]
    [Route("api/{Controller}")]
    public class CategoryController : ControllerBase
    {

        private readonly IServiceWrapping _serviceWrapping;
        private readonly IMapper _mapper;
        public CategoryController(IServiceWrapping serviceWrapping, IMapper mapper)
        {
            _serviceWrapping = serviceWrapping;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> get()
        {

            var categories = await _serviceWrapping.categoryService.list();

            if (categories == null) return NotFound();

            return Ok(categories);
        }

        [HttpGet("{name}")]
        public async Task<IActionResult> getByName(string name)
        {

            var category = await _serviceWrapping.categoryService.getCategoryByName(name);

            if (category == null) return NotFound();

            return Ok(category);
        }



        [HttpPost]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> add(Category category)
        {
            var result = await _serviceWrapping.categoryService.add(category);

            if (!result.Status) return BadRequest(result.Error);

            return CreatedAtAction(nameof(getByName),new {name=category.CategoryName},category);
        }

        [HttpPut("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> edit(int id, CategoryDTO category)
        {
            var cate = _mapper.Map<Category>(category);

            var result = await _serviceWrapping.categoryService.Edit(cate);

            if (!result.Status)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        [ServiceFilter(typeof(ValidationFilterAttribute))]
        public async Task<IActionResult> remove(int id, CategoryDTO category)
        {
            var cate = _mapper.Map<Category>(category);

            var result = await _serviceWrapping.categoryService.Remove(cate);

            if (!result.Status)
            {
                return BadRequest(result.Error);
            }

            return NoContent();
        }
    }
}