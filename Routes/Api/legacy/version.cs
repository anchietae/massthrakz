namespace massthrakz.Routes.Api.legacy;

public static class Version
{
    public static IEndpointRouteBuilder Legacy_Version(this WebApplication app)
    {
        app.MapGet("/api/legacy/version", () =>
        {
            
        });
        return app;
    }
}