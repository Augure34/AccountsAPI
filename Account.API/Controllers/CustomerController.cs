using Account.API.Models;
using Account.API.Specifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    public class CustomerController : ControllerBase
    {
        readonly ICustomerSpecification _customerSpecification;
        public CustomerController(ICustomerSpecification customerSpecification)
        {
            _customerSpecification = customerSpecification;
        }

        [HttpGet("customers/{customerId}")]
        public async Task<ActionResult<Customer>> Get([FromRoute] string customerId)
        {
            return Ok(await _customerSpecification.GetCustomer(customerId));
        }
    }
}
