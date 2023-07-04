using Microsoft.AspNetCore.Http;

namespace Template.Common.Models;

public enum ErrorCode
{
    /// <summary>
    /// Не найдено
    /// </summary>
    NoError = 0,

    /// <summary>
    /// Внутренняя ошибка
    /// </summary>
    UnDefined = 90_001,

    /// <summary>
    /// Ошибка валидации
    /// </summary>
    Validation = 90_002,

    /// <summary>
    /// Ошибка авторизации
    /// </summary>
    Unauthorized = 90_003,

    /// <summary>
    /// Не найдено
    /// </summary>
    NotFound = 90_004,

    /// <summary>
    /// Ошибка запроса
    /// </summary>
    BadRequest = 90_005,

    /// <summary>
    /// Ошибка получения значения из справочника
    /// </summary>
    InvalidReferenceCode = 90_006,

    /// <summary>
    /// Не удалось получить успешный ответ на запрос интеграции
    /// </summary>
    NotSuccessIntegrationResponse = 90_007,
}

public static class ErrorCodeExtensions
{
    public static string GetMessage(this ErrorCode errorCode)
    {
        switch (errorCode)
        {
            case ErrorCode.NotFound:
                return "Не найдено";
            case ErrorCode.Validation:
                return "Ошибка валидации";
            case ErrorCode.Unauthorized:
                return "Ошибка авторизации";
            case ErrorCode.BadRequest:
                return "Ошибка запроса";
            case ErrorCode.InvalidReferenceCode:
                return "Ошибка получения значения из справочника";
            case ErrorCode.NotSuccessIntegrationResponse:
                return "Не удалось получить успешный ответ на запрос интеграции";
            case ErrorCode.UnDefined:
            default:
                return "Внутренняя ошибка";
        }
    }

    public static int ToHttpStatusCode(this ErrorCode errorCode)
    {
        switch (errorCode)
        {
            case ErrorCode.NoError:
                return StatusCodes.Status200OK;
            case ErrorCode.Validation:
                return StatusCodes.Status400BadRequest;
            case ErrorCode.Unauthorized:
                return StatusCodes.Status401Unauthorized;
            case ErrorCode.NotFound:
            case ErrorCode.BadRequest:
            case ErrorCode.InvalidReferenceCode:
                return StatusCodes.Status422UnprocessableEntity;
            case ErrorCode.UnDefined:
            default:
                return StatusCodes.Status500InternalServerError;
        }
    }
}