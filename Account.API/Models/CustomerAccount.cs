namespace Account.API.Models
{
    public class CustomerAccount
    {
        public string Id { get; set; }
        public decimal Balance { get; set; }
        public string CustomerId { get; set; }
        public AccountTypeEnum AccountType { get; set; }
    }
}
