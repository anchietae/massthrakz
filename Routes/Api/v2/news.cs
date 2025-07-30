using massthrakz.Shared;

namespace massthrakz.Routes.Api.v2;


public static class NewsEndpoint
{
    public static IEndpointRouteBuilder News(this WebApplication app)
    {
        var newsService = app.Services.GetRequiredService<NewsService>();
        
        app.MapGet("/api/v2/news", (NewsService service) =>
        {
            return Results.Json(service.GetAllNews(), AppModels.Default.ListNewsResponse);
        });
        return app;
    }
}