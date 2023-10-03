using Dadabase.Data;
using FluentAssertions;
using Newtonsoft.Json;
using System.Net.Http.Json;
using System.Xml.Linq;

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
    public async Task GettingJokeGetsGoodStatusCode()
    {
        var response = await httpClient.GetAsync("/v1/joke");
        var results = await response.Content.ReadAsStringAsync();
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CanPostJoke()
    {
        JokeRequest joke = new JokeRequest
        {
            id = 5,
            name = "Calendar",
            jokeText = "Did you hear about the two people who stole a calendar? They each got six months",
        };

        var response = await httpClient.PostAsJsonAsync("/v1/joke", joke);
        var expected = response.Content.ReadFromJsonAsync<JokeDTO>();

        var joke1 = await httpClient.GetFromJsonAsync<JokeDTO>("/v1/joke/5");
        joke1.Should().BeEquivalentTo(new JokeDTO
        {
            name = "Calendar",
            jokeText = "Did you hear about the two people who stole a calendar? They each got six months",
            lastDateDelivered = "No Joke Date Found",
            categories = ""
        });
    }

    [Fact] 
    public async Task PostingJokeGetsGoodStatusCode()
    {
        JokeRequest joke = new JokeRequest
        {
            id = 5,
            name = "Calendar",
            jokeText = "Did you hear about the two people who stole a calendar? They each got six months",
        };

        var response = await httpClient.PostAsJsonAsync("/v1/joke", joke);
        var expected = response.Content.ReadFromJsonAsync<JokeDTO>();
        Assert.True(response.IsSuccessStatusCode);
    }

    [Fact]
    public async Task CanUpdateJoke()
    {
        JokeDTO newJoke = new JokeDTO
        {
            jokeText = "more nonsense"
        };

        var response = await httpClient.PatchAsJsonAsync("/v1/joke/1", newJoke);
        var expected = response.Content.ReadFromJsonAsync<JokeDTO>();

        var joke1 = await httpClient.GetFromJsonAsync<JokeDTO>("/v1/joke/1");
        joke1.Should().BeEquivalentTo(new JokeDTO
        {
            name = "golden soup",
            jokeText = "more nonsense",
            lastDateDelivered = "10/20/2023",
            categories = ""
        });     
    }
}
