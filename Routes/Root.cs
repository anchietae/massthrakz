namespace massthrakz.Routes;
using Shared;

public static class Root
{
    public static IEndpointRouteBuilder RootPath(this WebApplication app)
    {
        app.MapGet("/", () => Results.Content("Hello from MassTHrakz, I hope you will have a g'day!\n" +
                                         "For the source code, view: https://git.anchietae.cc/anchietae/massthrakz or https://github.com/anchietae/massthrakz\n" +
            "This API is actually stable, safe, performant and 'blazingly' (fucking) fast.\n"+
            "For api routes I recommend you to view the source code, but I list some of them for you\n"+
            "\n"+
            "/api/legacy/* /api/v1/* /api/web/*\n"+
            "Pretty simple and organized...\n"+
            "A few routes are cache their response (for 1 minutes) for everyone after getting requested without a cache. (Have you seen something like this?)\n"+
            "And a few stuff that requires IO operations are cached for 1 hours.", "text/plain")).WithCache();
        return app;
    }
}