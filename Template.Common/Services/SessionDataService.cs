using Template.Common.Interfaces;
using Template.Common.Models;

namespace Template.Common.Services;

public class SessionDataService : ISessionDataService
{
    public ConnectionInfo? ConnectionInfo { get; private set; }

    public RequestInfo? RequestInfo { get; private set; }

    public JwtInfo? JwtInfo { get; private set; }

    internal virtual void Initialize(ConnectionInfo connectionInfo, RequestInfo requestInfo, JwtInfo jwtInfo)
    {
        ConnectionInfo = connectionInfo;
        RequestInfo = requestInfo;
        JwtInfo = jwtInfo;
    }
}