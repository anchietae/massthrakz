namespace massthrakz;
using System.Text.Json.Serialization;

// yes please c#, don't allow me to just send a json without serialization

public record HealthStatus(bool Live);
[JsonSerializable(typeof(HealthStatus))]
[JsonSerializable(typeof(HealthStatus[]))]

internal partial class AppModels : JsonSerializerContext
{
}