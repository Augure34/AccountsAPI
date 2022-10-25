using Account.API.Models;
using Account.API.Repositories.Interfaces;

namespace Account.API.Repositories
{
    public class CustomerAccountRepository : ICustomerAccountRepository
    {
        readonly IDataStorage _dataStorage;
        public CustomerAccountRepository(IDataStorage dataStorage)
        {
            _dataStorage = dataStorage;
        }
        public IQueryable<CustomerAccount> GetCustomerAccounts(string customerId)
        {
            return _dataStorage.CustomersAccount.Where(x => x.CustomerId.Equals(customerId));
        }

        public CustomerAccount CreateAccount(CustomerAccount customerAccount)
        {
            _dataStorage.CustomersAccount = _dataStorage.CustomersAccount.Append(customerAccount);
            return customerAccount;
        }
    }
}
