using Database;

namespace WebApp.Customer;

public class CustomerService
{
    private readonly ICustomerRepository _customerRepository;

    public CustomerService(ICustomerRepository customerRepository)
    {
        _customerRepository = customerRepository;
    }
    
    public async ValueTask<IEnumerable<Domain.Entities.Customer>> GetCustomers()
    {
        return await _customerRepository.GetCustomers();
    }

    public async ValueTask AddCustomer(Domain.Entities.Customer customer)
    {
        await _customerRepository.AddCustomer(customer);
    }
}