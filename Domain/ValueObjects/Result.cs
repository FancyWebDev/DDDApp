namespace Domain.ValueObjects;

public class Result<T> where T: class
{
    public bool IsFailure => Value == null;
    public string Message { get; private set; }
    public T Value { get; private set; }

    private Result(T value)
    {
        Value = value;
    }

    private Result(string message)
    {
        Message = message;
    }

    public static Result<T> Success(T value) => new(value);
    public static Result<T> Failure(string message) => new(message);
}