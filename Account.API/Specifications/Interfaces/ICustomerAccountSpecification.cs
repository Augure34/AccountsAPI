using Account.API.Models;

namespace Account.API.Specifications.Interfaces
{
    public interface ICustomerAccountSpecification
    {
        Task<CustomerAccount> CreateAccount(string customerId, decimal initialCredit);
        Task<IEnumerable<CustomerAccount>> GetAllCustomerAccounts(string customerId);
    }
}
