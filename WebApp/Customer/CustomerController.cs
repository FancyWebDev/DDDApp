using Domain.ValueObjects;
using Microsoft.AspNetCore.Mvc;

namespace WebApp.Customer;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
    private readonly CustomerService _customerService;

    public CustomerController(CustomerService customerService)
    {
        _customerService = customerService;
    }

    [HttpGet]
    public async ValueTask<IActionResult> GetAll()
    {
        var customers = await _customerService.GetCustomers();
        return Ok(customers);
    }

    [HttpPost]
    public async ValueTask<IActionResult> Create([FromBody] CustomerDto customerDto)
    {
        var emailResult = Email.Create(customerDto.Email);
        if (emailResult.IsFailure)
             return BadRequest(emailResult.Message);
        
        var customer = new Domain.Entities.Customer(emailResult.Value, customerDto.Name);
        await _customerService.AddCustomer(customer);
        
        return Ok();
    }
}