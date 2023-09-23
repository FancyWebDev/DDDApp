using Domain.Entities;

namespace Database;

public class CustomerRepository : ICustomerRepository
{
    private readonly DataContext _dataContext;

    public CustomerRepository(DataContext dataContext)
    {
        _dataContext = dataContext;
    }
    
    public async ValueTask AddCustomer(Customer customer)
    {
        await _dataContext.AddAsync(customer);
        await _dataContext.SaveChangesAsync();
    }

    public async ValueTask<IEnumerable<Customer>> GetCustomers()
    {
        return await _dataContext.GetCustomers();
    }
}