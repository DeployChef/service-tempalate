using System.ComponentModel.DataAnnotations;
using MediatR;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Logging.Abstractions;
using Template.Common.Interfaces;
using Template.Common.Models;

namespace Template.Common.Mediator.Pipelines;

public class ExceptionBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
    where TRequest : IRequest<TResponse>
{
    private readonly IErrorCodeConfigurator _errorCodeConfigurator;
    private readonly ILogger<ExceptionBehavior<TRequest, TResponse>> _logger;

    public ExceptionBehavior(IErrorCodeConfigurator errorCodeConfigurator, ILogger<ExceptionBehavior<TRequest, TResponse>>? logger = null)
    {
        _errorCodeConfigurator = errorCodeConfigurator;
        _logger = logger ?? new NullLogger<ExceptionBehavior<TRequest, TResponse>>();
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        try
        {
            var response = await next();
            return response;
        }
        catch (Exception e)
        {
            var response = Activator.CreateInstance<TResponse>();

            switch (e)
            {
                case ValidationException:
                    response.SerError(_errorCodeConfigurator.ValidationCode, e.Message);
                    break;
                default:
                    response.SerError(_errorCodeConfigurator.UndefinedCode, e.Message);
                    break;
            }

            _logger.LogError(e, "Exception request. Name = {RequestName}. Response = {Response}", typeof(TRequest).Name, response);

            return response;
        }
    }
}