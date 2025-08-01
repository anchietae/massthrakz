using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.Extensions.Caching.Memory;

namespace massthrakz.Shared;

public static class Cache
{
    public static RouteHandlerBuilder WithCache(this RouteHandlerBuilder builder, int minutes = 1)
    {
        builder.AddEndpointFilter(async (context, next) =>
        {
            var cache = context.HttpContext.RequestServices.GetRequiredService<IMemoryCache>();
            var cacheKey = context.HttpContext.Request.GetDisplayUrl();

            if (cache.TryGetValue(cacheKey, out var result))
            {
                return result;
            }

            var newResult = await next(context);

            cache.Set(cacheKey, newResult, TimeSpan.FromMinutes(minutes));

            return newResult;
        });
        return builder;
    }
}
