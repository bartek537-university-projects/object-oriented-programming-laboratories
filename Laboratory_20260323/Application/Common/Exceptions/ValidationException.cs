namespace Laboratory_20260323.Application.Common.Exceptions;

public class ValidationException(IReadOnlyDictionary<string, string> errors) : Exception
{
    public IReadOnlyDictionary<string, string> Errors { get; } = errors;
}
