using Account.API.Models;
using Account.API.Services.Interfaces;

namespace Account.API.Services
{
    public class TransactionService : ITransactionService
    {
        public void TransferMoney(CustomerAccount senderAccount, CustomerAccount recipientAccount, decimal amount)
        {
            if (amount > 0 && senderAccount?.Balance >= amount)
            {
                senderAccount.Balance -= amount;
                recipientAccount.Balance += amount;
            }
            else
            {
                throw new Exception("Insufficient provision in sender account");
            }
        }
    }
}
