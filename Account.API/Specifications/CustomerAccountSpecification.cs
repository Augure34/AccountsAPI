using Account.API.Models;
using Account.API.Services.Interfaces;
using Account.API.Specifications.Interfaces;

namespace Account.API.Specifications
{
    public class CustomerAccountSpecification : ICustomerAccountSpecification
    {
        readonly ICustomerService _customerService;
        readonly ICustomerAccountService _customerAccountService;
        readonly ITransactionService _transactionService;
        public CustomerAccountSpecification(ICustomerService customerService, ICustomerAccountService customerAccountService, ITransactionService transactionService)
        {
            _customerAccountService = customerAccountService;
            _transactionService = transactionService;
            _customerService = customerService;
        }
        public Task<CustomerAccount> CreateAccount(string customerId, decimal initialCredit)
        {
            Customer customer = _customerService.GetCustomer(customerId);

            if (customer is null)
                throw new InvalidOperationException("Cannot open account for non existing customer");

            CustomerAccount createdAccount = _customerAccountService.CreateAccount(customerId);

            if (initialCredit is > 0)
            {
                _transactionService.TransferMoney(_customerAccountService.GetCheckingAccount(customerId)!, createdAccount, initialCredit);
            }

            return Task.FromResult(createdAccount);
        }

        public Task<IEnumerable<CustomerAccount>> GetAllCustomerAccounts(string customerId)
        {
            return Task.FromResult(_customerAccountService.GetAllCustomerAccounts(customerId));
        }
    }
}
