using System.Collections.Concurrent;
using Microsoft.Extensions.Options;

namespace massthrakz.Shared;

public class VersionService(IHttpClientFactory httpClientFactory, IOptions<AppSettings> appSettings)
    : IHostedService, IDisposable
{
    private readonly AppSettings _appSettings = appSettings.Value;
    private readonly ConcurrentDictionary<string, List<Release>> _cachedReleases = new();
    private Timer? _timer;

    public Task StartAsync(CancellationToken cancellationToken)
    {
        _timer = new Timer(DoWorkWrapper, null, TimeSpan.Zero, TimeSpan.FromHours(1));
        return Task.CompletedTask;
    }

    private async Task DoWork()
    {
        if (_appSettings.VersionSources == null)
        {
            Console.WriteLine("VersionSources is null");
            return;
        }

        var client = httpClientFactory.CreateClient();
        client.DefaultRequestHeaders.Add("User-Agent", "massthrakz");
        
        foreach (var (name, url) in _appSettings.VersionSources)
        {
            try
            {
                var releases = await client.GetFromJsonAsync(url, AppModels.Default.ListRelease);
                if (releases == null) continue;
                _cachedReleases[name] = releases;
                Console.WriteLine($"Loaded {releases.Count} releases for {name}");
            }
            catch (Exception)
            {
                Console.WriteLine($"Error fetching releases from {url}");
            }
        }
    }
    
    private async void DoWorkWrapper(object? state)
    {
        try
        {
            await DoWork();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error in DoWork see message: {ex.Message}");
        }
    }

    public List<Release>? GetReleases(string name)
    {
        _cachedReleases.TryGetValue(name, out var releases);
        return releases;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _timer?.Change(Timeout.Infinite, 0);
        return Task.CompletedTask;
    }

    public void Dispose()
    {
        _timer?.Dispose();
        GC.SuppressFinalize(this);
    }
}
