using Account.API.Models;

namespace Account.API.Repositories.Interfaces
{
    public interface ICustomerRepository
    {
        IQueryable<Customer> GetCustomers();
    }
}
