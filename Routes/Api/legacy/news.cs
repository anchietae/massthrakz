using massthrakz.Shared;
namespace massthrakz.Routes.Api.legacy;


public static class NewsLegacy
{
    public static IEndpointRouteBuilder Legacy_News(this WebApplication app)
    {
        var newsService = app.Services.GetRequiredService<NewsService>();
        
        app.MapGet("/api/legacy/news", (NewsService service) =>
        {
            return Results.Json(service.GetLegacyNews(), AppModels.Default.ListLegacyNewsResponse);
        });
        return app;
    }
}