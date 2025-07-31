// ReSharper disable InconsistentNaming
namespace massthrakz;
using System.Text.Json.Serialization;

// yes please c#, don't allow me to just send a json without serialization

public record HealthStatus(bool Live);

public record Legacy_ConfigJSON(Guid refilc_uinid, string user_agent = "hu.ekreta.student/$0/$1/$2");

public record NewsResponse(
    string title,
    string content,
    string? button_title,
    string? button_link,
    string expiry_date,
    List<string>? platforms
);

public record LegacyNewsResponse(
    string id,
    string title,
    string content,
    string link,
    string open_label,
    string platform,
    string expire_date
);

public record LegacyDownloadUrl(
    string android,
    string ios
);

public record LegacyVersionsRes(
    LegacyDownloadUrl download_url,
    bool is_latest,
    bool must_update,
    List<string> @new,
    string version
);

[JsonSerializable(typeof(HealthStatus))]
[JsonSerializable(typeof(HealthStatus[]))]
[JsonSerializable(typeof(Legacy_ConfigJSON))]
[JsonSerializable(typeof(NewsResponse))]
[JsonSerializable(typeof(List<NewsResponse>))]
[JsonSerializable(typeof(LegacyNewsResponse))]
[JsonSerializable(typeof(List<LegacyNewsResponse>))]
[JsonSerializable(typeof(LegacyDownloadUrl))]
[JsonSerializable(typeof(LegacyVersionsRes))]
[JsonSerializable(typeof(List<LegacyVersionsRes>))]
[JsonSerializable(typeof(Release))]
[JsonSerializable(typeof(List<Release>))]
public partial class AppModels : JsonSerializerContext
{
}

public class Release
{
    [JsonPropertyName("tag_name")]
    public required string TagName { get; set; }

    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("body")]
    public required string Body { get; set; }

    [JsonPropertyName("assets")]
    public required List<Asset> Assets { get; set; }
}

public class Asset
{
    [JsonPropertyName("name")]
    public required string Name { get; set; }

    [JsonPropertyName("browser_download_url")]
    public required string BrowserDownloadUrl { get; set; }
}