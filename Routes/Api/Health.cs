namespace massthrakz.Routes.Api;

public static class Health
{
    // pretty simple health endpoint, literally pointless, bc if the server is down, then this page wouldn't work tho
    // but most of the apis has this for some reason, idk
    public static IEndpointRouteBuilder MapHealth(this WebApplication app)
    {
        app.MapGet("/api/health", () =>
        {
            return Results.Ok(new HealthStatus(true));
        });
        return app;
    }
}


