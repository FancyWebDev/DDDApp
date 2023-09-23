namespace Database;

public interface ICustomerRepository
{
    ValueTask AddCustomer(Domain.Entities.Customer customer);
    ValueTask<IEnumerable<Domain.Entities.Customer>> GetCustomers();
}