namespace Admin.App;

public class CookieDelegatingHandler : DelegatingHandler
{
    private readonly IHttpContextAccessor _ctx;
    public CookieDelegatingHandler(IHttpContextAccessor ctx)
        => _ctx = ctx;

    protected override Task<HttpResponseMessage> SendAsync(
        HttpRequestMessage request, CancellationToken ct)
    {
        var cookie = _ctx.HttpContext?.Request.Headers["Cookie"].ToString();
        if (!string.IsNullOrEmpty(cookie))
            request.Headers.Add("Cookie", cookie);
        return base.SendAsync(request, ct);
    }
}