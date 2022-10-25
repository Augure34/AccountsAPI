namespace Account.API.Models
{
    public class Transaction
    {
        public CustomerAccount SenderAccount { get; set; }

        public CustomerAccount RecipientAccount { get; set; }

        public decimal Value { get; set; }
    }
}
