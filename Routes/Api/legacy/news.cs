using massthrakz.Shared;
namespace massthrakz.Routes.Api.legacy;


public static class NewsLegacy
{
    public static IEndpointRouteBuilder Legacy_News(this WebApplication app)
    {
        app.MapGet("/api/legacy/news", (NewsService service) => Results.Json(service.GetLegacyNews(), AppModels.Default.ListLegacyNewsResponse)).WithCache();
        return app;
    }
}