using Account.API.Models;

namespace Account.API.Services.Interfaces
{
    public interface ICustomerService
    {
        Customer GetCustomer(string customerId);
    }
}
