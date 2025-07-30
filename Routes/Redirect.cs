namespace massthrakz.Routes;
using Microsoft.Extensions.Options;
using massthrakz;

/*
 * this is the redirect endpoint that you can configure in appsettings.json
 * you can configure it in appsettings.json, the example is in the file
 */
public static class Redirect
{
    public static IEndpointRouteBuilder MapRedirects(this WebApplication app)
    {
        var appSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;
        if (appSettings.Redirects != null && appSettings.Redirects.Any())
        {
            foreach (var rule in appSettings.Redirects)
            {
                var newDestination = rule.Dest;
                if (string.IsNullOrWhiteSpace(newDestination))
                {
                    continue;
                }
                
                if (rule.Paths != null && rule.Paths.Any())
                {
                    foreach (var oldPath in rule.Paths)
                    {
                        if (string.IsNullOrWhiteSpace(oldPath))
                        {
                            continue;
                        }
                        app.MapGet(oldPath, (HttpContext context) =>
                        {
                            context.Response.Redirect(newDestination, permanent: true);
                            return Results.Empty;
                        });
                    }
                }
                else
                {
                    Console.WriteLine($"WARN: '{newDestination}' has no paths");
                }
            }
        }
        else
        {
            Console.WriteLine("No redirect rules set");
        }
        
        return app;
    }
}