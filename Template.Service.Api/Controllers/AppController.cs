using MediatR;
using Microsoft.AspNetCore.Mvc;
using Template.Common;
using Template.Common.DTO;
using Template.Common.Extensions;

namespace Template.Service.Api.Controllers;

/// <summary>
/// App
/// </summary>
[Produces("application/json")]
public class AppController : ApiControllerBase
{
    private readonly IMediator _mediator;

    public AppController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status400BadRequest)]
    [HttpGet]
    public async Task<IActionResult> Get(CancellationToken cancellationToken)
    {
        var result = ResultFactory.New();
        return result.ToHttpResponse();
    }
}
