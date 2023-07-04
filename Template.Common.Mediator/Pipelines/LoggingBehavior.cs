using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Template.Common.Models;

namespace Template.Common.Mediator.Pipelines;

public class LoggingBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
    where TRequest : IRequest<TResponse>
{
    private readonly ILogger<LoggingBehavior<TRequest, TResponse>> _logger;

    public LoggingBehavior(ILogger<LoggingBehavior<TRequest, TResponse>>? logger)
    {
        _logger = logger ?? new NullLogger<LoggingBehavior<TRequest, TResponse>>();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Handling request. Name = {RequestName}. Request = {Request}", typeof(TRequest).Name, request);

        var response = await next();

        if (response.IsSuccess)
            _logger.LogInformation("Successful request. Name = {RequestName}. Response = {Response}", typeof(TRequest).Name, response);
        else
            _logger.LogError("Error request. Name = {RequestName}. Response = {Response}", typeof(TRequest).Name, response);

        return response;
    }
}