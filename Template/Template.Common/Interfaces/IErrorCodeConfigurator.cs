namespace Template.Common.Interfaces;

public interface IErrorCodeConfigurator
{
    int UndefinedCode { get; }

    int ValidationCode { get; }

    int UnauthorizedCode { get; }
}