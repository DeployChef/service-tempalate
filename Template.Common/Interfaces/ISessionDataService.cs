using Template.Common.Models;

namespace Template.Common.Interfaces;

public interface ISessionDataService
{
    public ConnectionInfo? ConnectionInfo { get; }

    public RequestInfo? RequestInfo { get; }

    public JwtInfo? JwtInfo { get; }
}