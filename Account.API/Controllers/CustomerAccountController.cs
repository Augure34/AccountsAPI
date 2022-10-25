using Account.API.Models;
using Account.API.Specifications.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Account.API.Controllers
{
    [ApiController]
    public class CustomerAccountController : ControllerBase
    {
        readonly ICustomerAccountSpecification _accountSpecification;
        public CustomerAccountController(ICustomerAccountSpecification accountSpecification)
        {
            _accountSpecification = accountSpecification;
        }

        [HttpPut("customers/{customerId}/customerAccounts")]
        public async Task<ActionResult<CustomerAccount>> Put([FromRoute] string customerId, [FromBody] decimal initialCredit = default)
        {
            return Ok(await _accountSpecification.CreateAccount(customerId, initialCredit));
        }

        [HttpGet("customers/{customerId}/customerAccounts")]
        public async Task<ActionResult<IEnumerable<CustomerAccount>>> GetAll([FromRoute] string customerId)
        {
            return Ok(await _accountSpecification.GetAllCustomerAccounts(customerId));
        }
    }
}
