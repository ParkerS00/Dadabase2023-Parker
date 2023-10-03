using Dadabase.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace Dadabase.IntegrationTests;

public class AudienceTests : IClassFixture<DadabaseApiWebApplicationFactory>
{
    private readonly HttpClient httpClient;

    public AudienceTests(DadabaseApiWebApplicationFactory factory)
    {
        httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task CanCallApi()
    {
        var audience1 = await httpClient.GetFromJsonAsync<Audience>("/v1/audience/1");
        audience1.Should().BeEquivalentTo(new Audience
        {
            Id = 1,
            Audiencename = "French Class",
            Description = null,
        }, o => o.Excluding(si => si.Categorizedaudiences));
    }
}
