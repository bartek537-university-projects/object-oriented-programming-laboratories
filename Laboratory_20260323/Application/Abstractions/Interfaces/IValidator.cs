namespace Laboratory_20260323.Application.Abstractions.Interfaces;

public interface IValidator<T>
{
    Dictionary<string, string> Validate(T value);
}
