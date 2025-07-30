using massthrakz.Routes.Api;

namespace massthrakz;
public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateSlimBuilder(args);
        
        builder.Services.ConfigureHttpJsonOptions(options =>
        {
            options.SerializerOptions.TypeInfoResolverChain.Insert(0, AppModels.Default);
        });
        
        var app = builder.Build();
        app.UseHttpsRedirection();

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
        app.MapHealth();
        
        Console.WriteLine("massthrakz finished bootstrapping");
        app.Run();
    }
}