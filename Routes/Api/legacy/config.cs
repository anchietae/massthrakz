namespace massthrakz.Routes.Api.legacy;

public static class Config
{
    public static IEndpointRouteBuilder Legacy_Config(this WebApplication app)
    {
        app.MapGet("/api/legacy/config", () =>
        {
            return Results.Json(new Legacy_ConfigJSON(refilc_uinid: Guid.NewGuid()), AppModels.Default.Legacy_ConfigJSON);
        });
        return app;
    }
}