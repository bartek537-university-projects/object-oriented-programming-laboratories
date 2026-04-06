namespace Laboratory_20260323.Application.Common.Exceptions;

public class ConflictException : Exception
{
    public ConflictException() : base() { }
    public ConflictException(string message) : base(message) { }
    public ConflictException(string message, Exception inner) : base(message, inner) { }
}
