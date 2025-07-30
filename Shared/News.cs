using System.Text.Json;
namespace massthrakz.Shared;

public class NewsService
{
    private List<NewsResponse> _cachedNews = new List<NewsResponse>();
    private static readonly string[] Platforms = { "android", "ios", "web", "all" };

    public void LoadNews()
    {
        var startupDir = AppDomain.CurrentDomain.BaseDirectory;
        var newsDirPath = Path.Combine(startupDir, "data", "news");

        if (!Directory.Exists(newsDirPath))
        {
            Console.WriteLine("News directory doesn't exist");
            return;
        }

        foreach (var fPath in Directory.EnumerateFiles(newsDirPath, "*.json"))
        {
            try
            {
                var filecontent = File.ReadAllText(fPath);
                var newsItem = JsonSerializer.Deserialize<NewsResponse>(filecontent, AppModels.Default.NewsResponse);

                if (newsItem == null) continue;
                if (newsItem.platforms == null || !newsItem.platforms.All(p => Platforms.Contains(p)))
                {
                    newsItem = newsItem with { platforms = new List<string> { "all" } };
                }

                _cachedNews.Add(newsItem);
            }
            catch (Exception e)
            {
                Console.WriteLine(e);
            }
        }

        Console.WriteLine($"Loaded {_cachedNews.Count} news");
    }
    
    public List<NewsResponse> GetAllNews()
    {
        return _cachedNews;
    }

    public List<LegacyNewsResponse> GetLegacyNews()
    {
        return _cachedNews.Select(item =>
        {
            var jsonString = JsonSerializer.Serialize(item, AppModels.Default.NewsResponse);
            string id = GenerateHash.Hash(jsonString).ToString();
            string expireDateString = item.expiry_date;

            return new LegacyNewsResponse(
                id, title: item.title, content: item.content, link: item.button_link ?? "https://firka.app",
                open_label: item.button_title ?? "Firka", platform: "all", expire_date: expireDateString);
        }).ToList();
    }
}