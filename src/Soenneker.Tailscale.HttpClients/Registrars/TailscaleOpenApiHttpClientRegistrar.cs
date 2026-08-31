using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Utils.HttpClientCache.Registrar;

namespace Soenneker.Tailscale.HttpClients.Registrars;

/// <summary>
/// Registers an authenticated HTTP client provider for Tailscale's API.
/// </summary>
public static class TailscaleOpenApiHttpClientRegistrar
{
    /// <summary>
    /// Adds <see cref="TailscaleOpenApiHttpClient"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddTailscaleOpenApiHttpClientAsSingleton(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddSingleton<ITailscaleOpenApiHttpClient, TailscaleOpenApiHttpClient>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="TailscaleOpenApiHttpClient"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddTailscaleOpenApiHttpClientAsScoped(this IServiceCollection services)
    {
        services.AddHttpClientCacheAsSingleton()
                .TryAddScoped<ITailscaleOpenApiHttpClient, TailscaleOpenApiHttpClient>();

        return services;
    }
}
