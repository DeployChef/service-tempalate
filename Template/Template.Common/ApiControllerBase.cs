using System.Net.Mime;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Template.Common.DTO;

namespace Template.Common;

/// <response code="422">Ошибка в бизнес логике</response>
/// <response code="500">Необработанная ошибка</response>
[ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status422UnprocessableEntity)]
[ProducesResponseType(typeof(ErrorDTO), StatusCodes.Status500InternalServerError)]
[ApiController]
[Consumes(MediaTypeNames.Application.Json)]
[Produces(MediaTypeNames.Application.Json)]
[Route("/api/v1/[controller]/[action]")]
public abstract class ApiControllerBase : ControllerBase
{
    
}

[Route("/api/v1/manage/[controller]/[action]")]
public abstract class ManageApiControllerBase : ApiControllerBase
{
    
}