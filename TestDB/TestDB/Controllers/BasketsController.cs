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
    [Route("api/Baskets")]
    public class BasketsController : ControllerBase
    {
    
        private static BasketService _basketService = new BasketService();
[HttpGet]
        public IActionResult GetBaskets()
        {


            return Ok(_basketService.GetAllBaskets());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBasket([FromRoute] int id)
        {

            var basket = _basketService.GetBasketByCustomerId(id);

            if (basket == null)
                return NotFound($"No basket found with Id: {id}");

            return Ok(basket);
        }


        [HttpPost]
        public async Task<IActionResult> PostBasket([FromBody] Basket basket)
        {

            _basketService.AddBasket(basket);

            return Created($"/{basket.BasketId}", basket);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateBasketInformation([FromRoute] int id, [FromBody] Basket basket)
        {
            _basketService.UpdateBasketInfo(id, basket);
            return Ok();
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteBasket([FromRoute] int id, [FromRoute] int productId)
        {
            _basketService.RemoveProductFromBasket(id);
            //_basketService.RemoveBasket(id);
            return Ok();
        }

        [HttpDelete("customers/{id}")]
        public async Task<IActionResult> ClearBasket([FromRoute] int id)
        {
            if (id == null)
                return NotFound($"No basket found with Customer Id: {id}");
            _basketService.ClearBasket(id);
            return Ok();
        }


    }
}