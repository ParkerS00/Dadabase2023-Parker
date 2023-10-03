using Dadabase.Data;
using FluentAssertions;
using System.Net.Http.Json;

namespace Dadabase.IntegrationTests;

public class JokeTests : IClassFixture<DadabaseApiWebApplicationFactory>
{
    private readonly HttpClient httpClient;

    public JokeTests(DadabaseApiWebApplicationFactory factory)
    {
        httpClient = factory.CreateDefaultClient();
    }

    [Fact]
    public async Task CanGetJoke()
    {
        var joke1 = await httpClient.GetFromJsonAsync<JokeDTO>("/v1/joke/1");
        joke1.Should().BeEquivalentTo(new JokeDTO
        {
            name = "golden soup",
            jokeText = "How do you turn soup into gold? Add 24 carrots.",
            lastDateDelivered = "10/20/2023",
            categories = ""
        });
    }

    [Fact]
    public async Task JokeGetsGoodStatusCode()
    {
        var response = await httpClient.GetAsync("/v1/joke");
        var results = await response.Content.ReadAsStringAsync();
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CanPostJoke()
    {
        JokeDTO jokeDTO = new JokeDTO
        {
            name = "Calendar",
            jokeText = "Did you hear about the two people who stole a calendar? They each got six months",
            lastDateDelivered = "10/3/2023",
            categories = "puns, ironic"
        };

        httpClient.PostAsJsonAsync();

    }
}
