using Account.API.Models;
using Account.API.Repositories.Interfaces;

namespace Account.API.Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        readonly IDataStorage _dataStorage;
        public CustomerRepository(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
        public IQueryable<Customer> GetCustomers()
        {
            return _dataStorage.Customers;
        }
    }
}
