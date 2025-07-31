namespace massthrakz.Routes.Api.web;

using Shared;

public static class WebVersion
{
    public static IEndpointRouteBuilder Web_Version(this WebApplication app)
    {
        app.MapGet("/api/web/version", (VersionService versionService) =>
        {
            var legacy = versionService.GetReleases("legacy");
            var extension = versionService.GetReleases("extension");
            if (legacy?.Count == 0 && extension?.Count == 0) return Results.NotFound();


            // we need these
            string legacyVersion;
            string ios;
            string arm64;
            string armeabi;
            if (legacy == null)
            {
                legacyVersion = "Unknown";
                ios = "";
                arm64 = "";
                armeabi = "";
            }
            else
            {
                var legacyLatest = legacy.First();
                legacyVersion = legacyLatest.TagName;
                ios = legacyLatest.Assets.Find(a => a.Name.EndsWith(".ipa"))?.BrowserDownloadUrl ?? "";
                arm64 = legacyLatest.Assets.Find(a => a.Name.Contains("arm64-v8a"))?.BrowserDownloadUrl ?? "";
                armeabi = legacyLatest.Assets.Find(a => a.Name.Contains("armeabi-v7a"))?.BrowserDownloadUrl ?? "";
            }

            string extensionVersion;
            if (extension == null)
            {
                extensionVersion = "Unknown";
            }
            else
            {
                var extensionLatest = extension.First();
                extensionVersion = extensionLatest.TagName;
            }

            return Results.Json(
                new WebVersionModel(extensionVersion, appVersion: legacyVersion, ipaURL: ios, arm64URL: arm64,
                    armeabiURL: armeabi), AppModels.Default.WebVersionModel);
        });
        return app;
    }
}