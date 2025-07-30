namespace massthrakz.Routes.Api.v1;

public static class Config
{
    public static IEndpointRouteBuilder Legacy_Config(this WebApplication app)
    {
        app.MapGet("/api/v1/config", () =>
        {
            return Results.Json(new Legacy_ConfigJSON(refilc_uinid: Guid.NewGuid()), AppModels.Default.Legacy_ConfigJSON);
        });
        return app;
    }
}