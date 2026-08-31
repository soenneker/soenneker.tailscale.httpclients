[![](https://img.shields.io/nuget/v/soenneker.tailscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.tailscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.httpclients/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.httpclients/actions/workflows/codeql.yml)

# Soenneker.Tailscale.HttpClients

Provides a cached `HttpClient` configured with Tailscale's API base address and bearer-token authentication.

## Installation

```bash
dotnet add package Soenneker.Tailscale.HttpClients
```

## Configuration

```json
{
  "Tailscale": {
    "ApiKey": "tskey-api-..."
  }
}
```

`ClientBaseUrl`, `AuthHeaderName`, and `AuthHeaderValueTemplate` can override the defaults when using a proxy or a different token scheme. The default base URL is `https://api.tailscale.com/api/v2/`, and the default authorization template is `Bearer {token}`.

## Usage

```csharp
using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Tailscale.HttpClients.Registrars;

services.AddTailscaleOpenApiHttpClientAsSingleton();

HttpClient client = await tailscaleHttpClient.Get(cancellationToken);
HttpResponseMessage response = await client.GetAsync(
    "tailnet/-/devices",
    cancellationToken);

response.EnsureSuccessStatusCode();
```

The provider owns its cached client. Disposing the provider removes and disposes that client; callers should not dispose the value returned by `Get` independently. Relative request paths should not start with `/`, so they remain under the `/api/v2/` base path.
