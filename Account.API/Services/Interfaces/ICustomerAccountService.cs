using Account.API.Models;

namespace Account.API.Services.Interfaces
{
    public interface ICustomerAccountService
    {
        CustomerAccount CreateAccount(string customerId);
        CustomerAccount? GetCheckingAccount(string customerId);
        IEnumerable<CustomerAccount> GetAllCustomerAccounts(string customerId);
    }
}
