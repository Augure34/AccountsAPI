using Account.API.Models;

namespace Account.API.Services.Interfaces
{
    public interface ITransactionService
    {
        void TransferMoney(CustomerAccount senderAccount, CustomerAccount recipientAccount, decimal amount);
    }
}
