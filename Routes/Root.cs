namespace massthrakz.Routes;
using Shared;

public static class Root
{
    public static IEndpointRouteBuilder RootPath(this WebApplication app)
    {
        app.MapGet("/", () => Results.Ok("Hello From MassTHrakz")).WithCache();
        return app;
    }
}