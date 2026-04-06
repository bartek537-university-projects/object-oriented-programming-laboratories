namespace Laboratory_20260323.Application.Abstractions.Interfaces;

public interface IRequestHandler<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    TResponse Handle(TRequest request);
}

