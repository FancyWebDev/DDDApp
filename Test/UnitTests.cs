using Domain.ValueObjects;

namespace Test;

public class UnitTests
{
    [Test]
    public void WhenCreateEmail_AndEmailIsInvalid_ThenEmailShouldNotBeCreated()
    {
        var invalidEmails = new List<Result<Email>>
        {
            Email.Create("some@example"),
            Email.Create("some$example.com"),
            Email.Create("some@examplecom"),
            Email.Create("someexample.com"),
        };

        foreach (var email in invalidEmails)
        {
            email.IsFailure.Should().BeTrue();
            email.Value.Should().BeNull();
        }
    }

    [Test]
    public void WhenCreateEmail_AndEmailIsValid_ThenEmailShouldBeCreated()
    {
        var invalidEmails = new List<Result<Email>>
        {
            Email.Create("some@example.com"),
            Email.Create("a1@some.eu")
        };

        foreach (var email in invalidEmails)
        {
            email.IsFailure.Should().BeFalse();
            email.Value.Should().NotBeNull();
        }
    }

    [Test]
    public void WhenCreateCustomerName_AndCustomerNameIsInvalid_ThenCustomerNameShouldNotBeCreated()
    {
        var invalidNames = new List<Result<CustomerName>>
        {
            CustomerName.Create(""),
            CustomerName.Create("a"),
            CustomerName.Create("12324"),
            CustomerName.Create("12324"),
        };

        foreach (var name in invalidNames)
        {
            name.IsFailure.Should().BeTrue();
            name.Value.Should().BeNull();
        }
    }

    [Test]
    public void WhenCreateCustomerName_AndCustomerNameIsValid_ThenCustomerNameShouldBeCreated()
    {
        var invalidNames = new List<Result<CustomerName>>
        {
            CustomerName.Create("a1"),
            CustomerName.Create("1a1"),
        };

        foreach (var name in invalidNames)
        {
            name.IsFailure.Should().BeFalse();
            name.Value.Should().NotBeNull();
        }
    }
}