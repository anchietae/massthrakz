using massthrakz.Shared;
namespace massthrakz.Routes.Api.v1;


public static class NewsLegacy
{
    public static IEndpointRouteBuilder Legacy_News(this WebApplication app)
    {
        var newsService = app.Services.GetRequiredService<NewsService>();
        
        app.MapGet("/api/v1/news", (NewsService service) =>
        {
            return Results.Json(service.GetLegacyNews(), AppModels.Default.ListLegacyNewsResponse);
        });
        return app;
    }
}