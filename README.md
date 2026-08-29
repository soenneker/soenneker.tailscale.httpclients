[![](https://img.shields.io/nuget/v/soenneker.tailscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.httpclients/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.tailscale.httpclients/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.tailscale.httpclients/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.tailscale.httpclients.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.tailscale.httpclients/)

# Soenneker.Tailscale.HttpClients

A .NET thread-safe singleton HttpClient for.

## Install

```bash
dotnet add package Soenneker.Tailscale.HttpClients
```

## Quick start

```csharp
using Soenneker.Tailscale.HttpClients.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddTailscaleOpenApiHttpClientAsSingleton();
```

Adds `TailscaleOpenApiHttpClient` as a singleton service.

## What you get

- `ITailscaleOpenApiHttpClient` — A .NET thread-safe singleton HttpClient for.
- `TailscaleOpenApiHttpClientRegistrar` — Registers the OpenAPI HttpClient wrapper for dependency injection.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `TailscaleOpenApiHttpClientRegistrar.AddTailscaleOpenApiHttpClientAsSingleton(services)` | Adds `TailscaleOpenApiHttpClient` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `TailscaleOpenApiHttpClientRegistrar.AddTailscaleOpenApiHttpClientAsScoped(services)` | Adds `TailscaleOpenApiHttpClient` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
