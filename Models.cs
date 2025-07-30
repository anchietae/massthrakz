namespace massthrakz;
using System.Text.Json.Serialization;

// yes please c#, don't allow me to just send a json without serialization

public record HealthStatus(bool Live);

[JsonSerializable(typeof(HealthStatus))]
[JsonSerializable(typeof(HealthStatus[]))]

public record Legacy_ConfigJSON(Guid refilc_uinid, string user_agent = "hu.ekreta.student/$0/$1/$2");
[JsonSerializable(typeof(Legacy_ConfigJSON))]

internal partial class AppModels : JsonSerializerContext
{
}