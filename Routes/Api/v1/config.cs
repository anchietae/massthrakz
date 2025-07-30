namespace massthrakz.Routes.Api.v1;

public static class Config
{
    public static IEndpointRouteBuilder Legacy_Config(this WebApplication app)
    {
        app.MapGet("/api/v1/config", () =>
        {
            return Results.Ok(new Legacy_ConfigJSON(refilc_uinid: Guid.NewGuid()));
        });
        return app;
    }
}