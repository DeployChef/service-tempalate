namespace Template.Common.Models;

public class JwtInfo
{
    public string? SessionId { get; set; }

    public string? Sub { get; set; }

    public string? Channel { get; set; }

    public string? Jti { get; set; }
}