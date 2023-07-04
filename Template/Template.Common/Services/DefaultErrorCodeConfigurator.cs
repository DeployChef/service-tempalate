using Template.Common.Interfaces;

namespace Template.Common.Services;

public class DefaultErrorCodeConfigurator : IErrorCodeConfigurator
{
    public int UndefinedCode { get; } = -1;

    public int ValidationCode { get; } = -2;

    public int UnauthorizedCode { get; } = -3;
}