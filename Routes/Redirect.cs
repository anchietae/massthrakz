using Microsoft.Extensions.Options;
namespace massthrakz.Routes;

/*
 * this is the redirect endpoint that you can configure in appsettings.json
 * you can configure it in appsettings.json, the example is in the file
 */
public static class Redirect
{
    public static IEndpointRouteBuilder MapRedirects(this WebApplication app)
    {
        var appSettings = app.Services.GetRequiredService<IOptions<AppSettings>>().Value;
        if (appSettings.Redirects != null && appSettings.Redirects.Count != 0)
        {
            foreach (var rule in appSettings.Redirects)
            {
                var newDestination = rule.Dest;
                if (string.IsNullOrWhiteSpace(newDestination))
                {
                    continue;
                }
                
                if (rule.Paths != null && rule.Paths.Count != 0)
                {
                    foreach (var oldPath in rule.Paths.Where(oldPath => !string.IsNullOrWhiteSpace(oldPath)))
                    {
                        app.MapGet(oldPath, context =>
                        {
                            context.Response.Redirect(newDestination, permanent: true);
                            return Task.CompletedTask;
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