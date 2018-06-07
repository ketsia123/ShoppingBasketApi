using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDB.Models;
using TestDB.Services;

namespace TestDB.Controllers
{
    //[Route("api/[controller]")]
    //[ApiController]
    [Produces("application/json")]
    [Route("api/Customers")]
    public class CustomersController : ControllerBase
    {
       
        private static CustomerService _customertService = new CustomerService();
        
      [HttpGet]
        public IActionResult GetProduct()
        {
            return Ok(_customertService.GetAllCustomers());
        }


        [HttpGet("{id}", Name = "GetCustomer")]
        public async Task<IActionResult> GetCustomer([FromRoute] int id)
        {

            var customer = CustomerService.GetCustomer();

            if (customer == null)
                return NotFound($"No customer found with Id: {id}");

            return Ok(customer);
        }

        
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer([FromRoute] int id, [FromBody] Customer customer)
        {
            _customertService.UpdateCustomer(id, customer);
            return Ok();
        }


        [HttpPost]
        public async Task<IActionResult> PostCustomer([FromBody] Customer customer)
        {
         
            _customertService.AddCustomer(customer);

            return Created($"/{customer.CustomerId}", customer);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer([FromRoute] int id)
        {
            _customertService.RemoveCustomerById(id);
            return Ok();
        }

    }
}