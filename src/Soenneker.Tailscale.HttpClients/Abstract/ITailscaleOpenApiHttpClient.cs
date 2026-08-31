using System;
using System.Net.Http;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Tailscale.HttpClients.Abstract;

/// <summary>
/// Provides an authenticated, cached <see cref="HttpClient"/> for Tailscale's API.
/// </summary>
public interface ITailscaleOpenApiHttpClient : IDisposable, IAsyncDisposable
{
    /// <summary>
    /// Removes and disposes the HTTP client owned by this provider.
    /// </summary>
    new void Dispose();

    /// <summary>
    /// Asynchronously removes and disposes the HTTP client owned by this provider.
    /// </summary>
    new ValueTask DisposeAsync();

    /// <summary>
    /// Returns the configured HTTP client used by the Tailscale OpenAPI HTTP Client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested HTTP client.</returns>
    ValueTask<HttpClient> Get(CancellationToken cancellationToken = default);
}
