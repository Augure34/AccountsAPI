using Account.API.Models;
using Account.API.Services.Interfaces;
using Account.API.Specifications.Interfaces;

namespace Account.API.Specifications
{
    public class CustomerSpecification : ICustomerSpecification
    {
        readonly ICustomerService _customerService;
        public CustomerSpecification(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        public Task<Customer> GetCustomer(string customerId)
        {
            return Task.FromResult(_customerService.GetCustomer(customerId));
        }
    }
}
