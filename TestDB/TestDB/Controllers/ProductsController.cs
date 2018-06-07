using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDB.Models;
using TestDB.Services;


namespace TestDB.Controllers
{
    [Produces("application/json")]
    [Route("api/Products")]
    public class ProductsController : Controller
    {
       
        private static ProductService _productService = new ProductService();

       

        [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_productService.GetAllProducts());
        }

        [HttpGet("{id}", Name = "GetProduct")]
        public async Task<IActionResult> GetProduct([FromRoute] int id)
        {
            var product = _productService.GetProductbyProductId(id);

            if (product == null)
                return NotFound($"No product found with Id: {id}");

            return Ok(product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutProduct([FromRoute] int id, [FromBody] Product product)
        {
            _productService.UpdateProduct(id, product);
            return Ok();
        }

        [HttpPost]
        public async Task<IActionResult> PostProduct([FromBody] Product product)
        {
         
            _productService.AddProduct(product);

            return Created($"/{product.ProductId}", product);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromRoute] int id)
        {
            _productService.RemoveProductById(id);
            return Ok();
        }
    }
}