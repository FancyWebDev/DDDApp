using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public class CustomerName : ValueObject
{
    private const string RegexPattern = @"[a-zA-Z]";
    private const uint MaxNameLength = 50;
    private const uint MinNameLength = 2;

    private CustomerName(string name)
    {
        Value = name;
    }

    public string Value { get; private set; }

    public static Result<CustomerName> Create(string value)
    {
        var name = value.Trim();
        
        var isMatchRegex = new Regex(RegexPattern).IsMatch(name);
        if (isMatchRegex == false)
            return Result<CustomerName>.Failure("Student name is invalid");

        var isValidLength = name.Length <= MaxNameLength && name.Length >= MinNameLength ;
        if (isValidLength == false)
            return Result<CustomerName>.Failure("Student name length is invalid");

        return Result<CustomerName>.Success(new CustomerName(name));
    }
}