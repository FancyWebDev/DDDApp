using Domain.ValueObjects;

namespace Domain.Entities;

public class Customer : Entity
{
    public int Identity { get; private set; }
    public string Name { get; private set; }
    public Email Email { get; private set; }

    public Customer() {}
    
    public Customer(Email email, string name)
    {
        Name = name;
        Email = email;
    }
}