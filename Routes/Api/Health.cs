namespace massthrakz.Routes.Api;
using Shared;

public static class Health
{
    // pretty simple health endpoint, literally pointless, bc if the server is down, then this page wouldn't work tho
    // but most of the apis has this for some reason, idk
    public static IEndpointRouteBuilder MapHealth(this WebApplication app)
    {
        app.MapGet("/api/health", () => Results.Json(new HealthStatus(true), AppModels.Default.HealthStatus)).WithCache();
        return app;
    }
}


