using Account.API.Models;
using Account.API.Repositories.Interfaces;
using Account.API.Services.Interfaces;

namespace Account.API.Services
{
    public class CustomerAccountService : ICustomerAccountService
    {
        readonly ICustomerAccountRepository _customerAccountRepository;
        public CustomerAccountService(ICustomerAccountRepository customerAccountRepository)
        {
            _customerAccountRepository = customerAccountRepository;
        }

        public CustomerAccount CreateAccount(string customerId)
        {
            return _customerAccountRepository.CreateAccount(new CustomerAccount()
            {
                Balance = 0,
                CustomerId = customerId,
                Id = Guid.NewGuid().ToString(),
                AccountType = AccountTypeEnum.Undefined
            });
        }

        public IEnumerable<CustomerAccount> GetAllCustomerAccounts(string customerId)
        {
            return _customerAccountRepository.GetCustomerAccounts(customerId);
        }

        public CustomerAccount? GetCheckingAccount(string customerId)
        {
            return _customerAccountRepository.GetCustomerAccounts(customerId)
                .SingleOrDefault(x => x.AccountType == AccountTypeEnum.Checking);
        }
    }
}
