namespace massthrakz.Routes.Api.legacy;

public static class Config
{
    public static IEndpointRouteBuilder Legacy_Config(this WebApplication app)
    {
        // this shouldn't be cached since it generates a new uuid at every get req
        app.MapGet("/api/legacy/config", () => Results.Json(new LegacyConfigJson(refilc_uinid: Guid.NewGuid()), AppModels.Default.LegacyConfigJson));
        return app;
    }
}