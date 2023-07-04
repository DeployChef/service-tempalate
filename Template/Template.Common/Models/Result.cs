namespace Template.Common.Models;

public record Result
{
    public bool IsSuccess => !ErrorCode.HasValue;

    public int? ErrorCode { get; private set; }

    public string? Message { get; private set; }

    public Result() { }

    public Result(int errorCode, string? message)
    {
        ErrorCode = errorCode;
        Message = message;
    }

    public void SerError(int errorCode, string? message)
    {
        ErrorCode = errorCode;
        Message = message;
    }

    public static Result Empty() => new();
}

public record Result<T> : Result
{
    public T? Data { get; private set; }

    public Result() { }

    public Result(T data)
    {
        Data = data;
    }

    public Result(T? data, int errorCode, string? message) : base(errorCode, message)
    {
        Data = data;
    }

    public Result(int errorCode, string? message) : base(errorCode, message)
    {
    }
}