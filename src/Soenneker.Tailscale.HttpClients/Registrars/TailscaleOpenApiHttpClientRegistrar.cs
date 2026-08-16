using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Tailscale.HttpClients.Registrars;

/// <summary>
/// Registers the OpenAPI HttpClient wrapper for dependency injection.
/// </summary>
public static class TailscaleOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="TailscaleOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddTailscaleOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ITailscaleOpenApiHttpClient, TailscaleOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TailscaleOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddTailscaleOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ITailscaleOpenApiHttpClient, TailscaleOpenApiHttpClient>();

        return services;
    }
}
