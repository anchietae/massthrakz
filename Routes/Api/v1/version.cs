namespace massthrakz.Routes.Api.v1;

public static class Version
{
    public static IEndpointRouteBuilder Legacy_Version(this WebApplication app)
    {
        app.MapGet("/api/v1/version", () =>
        {
            
        });
        return app;
    }
}