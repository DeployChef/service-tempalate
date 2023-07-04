using Template.Common.Models;

namespace Template.Common;

public class ResultFactory
{
    public static Result New(int? errorCode, string message) => new(errorCode ?? (int)ErrorCode.UnDefined, message);

    public static Result New(ErrorCode? errorCode, string message) => new(errorCode.HasValue ? (int)errorCode.Value : (int)ErrorCode.UnDefined, message);

    public static Result New(ErrorCode? errorCode) => new(errorCode.HasValue ? (int)errorCode.Value : (int)ErrorCode.UnDefined, string.Empty);

    public static Result New() => Result.Empty();

    public static Result<T> New<T>(T data, int? errorCode, string message) => new(data, errorCode ?? (int)ErrorCode.UnDefined, message);

    public static Result<T> New<T>(T data, ErrorCode? errorCode, string message) => new(data, errorCode.HasValue ? (int)errorCode.Value : (int)ErrorCode.UnDefined, message);

    public static Result<T> New<T>(T data) => new(data);
}