using massthrakz.Routes.Api;
using massthrakz.Routes;
using massthrakz.Routes.Api.legacy;
using massthrakz.Routes.Api.v1;
using massthrakz.Routes.Api.web;
using massthrakz.Shared;

namespace massthrakz;
public static class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        builder.Services.Configure<AppSettings>(builder.Configuration);
        
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppModels.Default);
        });

        builder.Services.AddCors(options =>
        {
            options.AddPolicy(name: "AllowAllOrigins",
                policy =>
                {
                    policy.WithOrigins("*")
                        .AllowAnyHeader()
                        .AllowAnyMethod();
                });
        });
        // news
        builder.Services.AddSingleton<NewsService>();
        // in memory cacher (1min), should be used on static/maybe static routes, but not always changing
        builder.Services.AddMemoryCache();
        // version service thing, for endpoints
        builder.Services.AddHttpClient();
        builder.Services.AddHostedService<VersionService>();
        builder.Services.AddSingleton<VersionService>(sp => sp.GetRequiredService<IEnumerable<IHostedService>>().OfType<VersionService>().First());
        
        var app = builder.Build();
        app.UseCors("AllowAllOrigins");

        /* dynamic routing won't work on aot publish
           but will work if you just build it without publishing it
           published vers are much smaller and faster
           health route comparison
           166843.55 req/sec - 81.94MB transfer/sec (normal build)
           193537.91 req/sec - 31.56MB transfer/sec (publish)
           the published ver can handle more reqs
           also this outperforms rust - take that rust femboys
           
           ^ this was tested on a laptop in perf mode (on battery - ~20%)
           specs: i5-1135G7 @ 2.40GHz (8 log core, 4 phys core, VT-x amd64)
                  PC711 NVMe SK hynix 512GB - PCIe 3.0 4x
                  some unbranded 16GiB DDR4 - 3200MT/s (2 slots) SODIMM, Synchronous
        */
        app.RootPath();
        app.MapHealth();
        app.Legacy_Config();
        
        // register newsservice globally
        var newsService = app.Services.GetRequiredService<NewsService>();
        newsService.LoadNews();
        app.Legacy_News();
        app.News();
        app.Legacy_Version();
        app.Web_Version();
        
        // this should always be on the bottom
        app.MapRedirects();
        Console.WriteLine("massthrakz finished bootstrapping");
        app.Run();
    }
}