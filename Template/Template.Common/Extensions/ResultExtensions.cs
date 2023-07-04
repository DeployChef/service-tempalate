using Microsoft.AspNetCore.Mvc;
using Template.Common.DTO;
using Template.Common.Models;

namespace Template.Common.Extensions;

public static class ResultExtensions
{
    public static IActionResult ToHttpResponse(this Result result)
    {
        var errorCode = result.ErrorCode.HasValue ? (ErrorCode)result.ErrorCode.Value : ErrorCode.UnDefined;
        return result.IsSuccess
            ? new NoContentResult()
            : new JsonResult(new ErrorDTO(result.Message, (int)errorCode)) { StatusCode = errorCode.ToHttpStatusCode() };
    }

    public static IActionResult ToHttpResponse<T>(this Result<T> result)
    {
        var errorCode = result.ErrorCode.HasValue ? (ErrorCode)result.ErrorCode.Value : ErrorCode.UnDefined;
        return result.IsSuccess
            ? new OkObjectResult(result.Data)
            : new JsonResult(new ErrorDTO(result.Message, (int)errorCode)) { StatusCode = errorCode.ToHttpStatusCode() };
    }

    public static IActionResult ToHttpResponse<T>(this Result<T> result, Func<T?, IActionResult> okResultFunc)
    {
        var errorCode = result.ErrorCode.HasValue ? (ErrorCode)result.ErrorCode.Value : ErrorCode.UnDefined;
        return result.IsSuccess
            ? okResultFunc(result.Data)
            : new JsonResult(new ErrorDTO(result.Message, (int)errorCode)) { StatusCode = errorCode.ToHttpStatusCode() };
    }
}