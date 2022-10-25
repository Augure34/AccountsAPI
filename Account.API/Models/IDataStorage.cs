namespace Account.API.Models
{
    public interface IDataStorage
    {
        IQueryable<Customer> Customers { get; set; }

        IQueryable<CustomerAccount> CustomersAccount { get; set; }
    }
}
