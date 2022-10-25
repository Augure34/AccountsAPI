using Account.API.Models;
using Account.API.Repositories.Interfaces;
using Account.API.Services.Interfaces;

namespace Account.API.Services
{
    public class CustomerService : ICustomerService
    {
        readonly ICustomerRepository _customerRepository;
        public CustomerService(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public Customer GetCustomer(string customerId)
        {
            var customer = _customerRepository.GetCustomers().SingleOrDefault(x => x.CustomerId == customerId);

            if (customer == null)
                throw new Exception("Customer not found");

            return customer;
        }
    }
}
