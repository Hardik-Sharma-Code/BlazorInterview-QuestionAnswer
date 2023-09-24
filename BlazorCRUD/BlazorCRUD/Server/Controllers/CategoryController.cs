using BlazorCRUD.Server.Services;
using BlazorCRUD.Shared;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryServices _categoryServices;

        public CategoryController(ICategoryServices categoryServices)
        {
            _categoryServices = categoryServices;
        }

        // GET: api/<CategoryController>
        [HttpGet]
        [Route("getCategories")]
        public async Task<IActionResult> Get()
        {
            var categoryList = await _categoryServices.GetCategories();
            return Ok(categoryList);
        }

        // GET api/<CategoryController>/5
        [HttpGet]
        [Route("getByID/{categoryId}")]
        public async Task<IActionResult> Get(string categoryId)
        {
            var category = await _categoryServices.GetById(categoryId);
            return Ok(category);
        }

        // POST api/<CategoryController>
        [HttpPost]
        [Route("addCategory")]
        public async Task<IActionResult> Post([FromBody] Category category)
        {
            var newCategory = await _categoryServices.CreateAsync(category);
            return Ok(newCategory);
        }

        // PUT api/<ValuesController>/5
        [HttpPut()]
        [Route("updateCategory/{categoryId}")]
        public async Task<IActionResult> Put(string categoryId, [FromBody] Category category)
        {
            var newCategory = await _categoryServices.UpdateAsync(categoryId ,category);
            return Ok(newCategory);
        }
    }
}
