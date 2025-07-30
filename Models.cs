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

[JsonSerializable(typeof(HealthStatus))]
[JsonSerializable(typeof(HealthStatus[]))]
[JsonSerializable(typeof(Legacy_ConfigJSON))]
[JsonSerializable(typeof(NewsResponse))]
[JsonSerializable(typeof(List<NewsResponse>))]
[JsonSerializable(typeof(LegacyNewsResponse))]
[JsonSerializable(typeof(List<LegacyNewsResponse>))]
public partial class AppModels : JsonSerializerContext
{
}