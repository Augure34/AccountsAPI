using Account.API.Models;

namespace Account.API.Repositories.Interfaces
{
    public interface ICustomerAccountRepository
    {
        CustomerAccount CreateAccount(CustomerAccount customerAccount);
        IQueryable<CustomerAccount> GetCustomerAccounts(string customerId);
    }
}
