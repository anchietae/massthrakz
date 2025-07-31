using massthrakz.Shared;

namespace massthrakz.Routes.Api.v1;


public static class NewsEndpoint
{
    public static IEndpointRouteBuilder News(this WebApplication app)
    {
        app.MapGet("/api/v1/news", (NewsService service) => Results.Json(service.GetAllNews(), AppModels.Default.ListNewsResponse));
        return app;
    }
}