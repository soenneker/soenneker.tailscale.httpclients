using Soenneker.Tailscale.HttpClients.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Tailscale.HttpClients.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public sealed class TailscaleOpenApiHttpClientTests : HostedUnitTest
{
    private readonly ITailscaleOpenApiHttpClient _httpclient;

    public TailscaleOpenApiHttpClientTests(Host host) : base(host)
    {
        _httpclient = Resolve<ITailscaleOpenApiHttpClient>(true);
    }

    [Test]
    public void Default()
    {

    }
}
