using BlazorCRUD.Server.Services;
using BlazorCRUD.Shared;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace BlazorCRUD.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly IProductServices _productServices;

        public ProductsController(IProductServices productServices)
        { 
            _productServices = productServices;
        }
        // GET: api/<ProductsController>
        [HttpGet]
        [Route("getProducts")]
        public async Task<IActionResult> Get()
        {
            var productList = await _productServices.GetProducts();
            return Ok(productList);
        }

        // GET api/<ProductsController>/5
        [HttpGet]
        [Route("getById/{id}")]
        public async Task<IActionResult> Get(string id)
        {
            var product = await _productServices.GetById(id);
            return Ok(product);
        }

        // POST api/<ProductsController>
        [HttpPost]
        [Route("addProduct")]
        public async Task<IActionResult> Post([FromBody] ProductDTO products)
        {
            var newProduct = await _productServices.CreateAsync(products);
            return Ok(newProduct);
        }

        // PUT api/<ProductsController>/5
        [HttpPut("{id}")]
        [Route("updateProduct/{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] ProductDTO products)
        {
            var updateProduct = await _productServices.CreateAsync(products);
            return Ok(updateProduct);
        }
    }
}
