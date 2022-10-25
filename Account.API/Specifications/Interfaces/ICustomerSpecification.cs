using Account.API.Models;

namespace Account.API.Specifications.Interfaces
{
    public interface ICustomerSpecification
    {
        Task<Customer> GetCustomer(string customerId);
    }
}
