namespace massthrakz.Routes.Api.legacy;
using Shared;

public static class Version
{
    public static IEndpointRouteBuilder Legacy_Version(this WebApplication app)
    {
        app.MapGet("/api/legacy/version", (VersionService versionService) =>
        {
            var releases = versionService.GetReleases("legacy");
            if (releases == null || releases.Count == 0) return Results.NotFound();

            var latestRelease = releases[0];

            var response = releases.Select(release =>
            {
                var isLatest = release == latestRelease;
                return new LegacyVersionsRes(
                    new LegacyDownloadUrl(
                        android: release.Assets.Find(a => a.Name.EndsWith(".apk"))?.BrowserDownloadUrl ?? "",
                        ios: release.Assets.Find(a => a.Name.EndsWith(".ipa"))?.BrowserDownloadUrl ?? ""
                    ),
                    is_latest: isLatest,
                    must_update: !isLatest,
                    @new: [],
                    version: release.TagName
                );
            }).ToList();

            return Results.Json(response, AppModels.Default.ListLegacyVersionsRes);
        }).WithCache();

        app.MapGet("/api/legacy/version/latest", (VersionService versionService) =>
        {
            var releases = versionService.GetReleases("legacy");
            if (releases == null || releases.Count == 0) return Results.NotFound();

            var latest = releases[0];

            return Results.Json(new LegacyVersionsRes(
                new LegacyDownloadUrl(
                    android: latest.Assets.Find(a => a.Name.EndsWith(".apk"))?.BrowserDownloadUrl ?? "",
                    ios: latest.Assets.Find(a => a.Name.EndsWith(".ipa"))?.BrowserDownloadUrl ?? ""
                ),
                is_latest: true,
                must_update: false,
                @new: [],
                version: latest.TagName
            ), AppModels.Default.LegacyVersionsRes);
        }).WithCache();
        return app;
    }
}