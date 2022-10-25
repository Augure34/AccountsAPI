namespace Account.API.Models
{
    public class FakeInMemoryStorage : IDataStorage
    {
        public IQueryable<Customer> Customers { get; set; } = new List<Customer>()
        {
            new Customer { Name = "Ghislain", Surname = "Rossi", CustomerId = "GRI"}
        }.AsQueryable();

        public IQueryable<CustomerAccount> CustomersAccount { get; set; } = new List<CustomerAccount>()
        {
            new CustomerAccount { CustomerId = "GRI", AccountType = AccountTypeEnum.Checking, Balance = 200, Id = "GRI-1"}
        }.AsQueryable();
    }
}
