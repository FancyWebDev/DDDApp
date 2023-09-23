using System.Text.RegularExpressions;

namespace Domain.ValueObjects;

public class Email : ValueObject
{
    private const string RegexPattern = @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$";
    private const uint MaxEmailLength = 100;

    private Email(string email)
    {
        Value = email;
    }
    
    public string Value { get; private set; }

    public static Result<Email> Create(string value)
    {
        var email = value.Trim();

        var isMatchRegex = new Regex(RegexPattern).IsMatch(email);
        if (isMatchRegex == false)
            return Result<Email>.Failure("Email is invalid");
        
        var isValidLength = email.Length <= MaxEmailLength;
        if(isValidLength == false)
            return Result<Email>.Failure("Email length is invalid");
        
        return Result<Email>.Success(new Email(email));
    }
}