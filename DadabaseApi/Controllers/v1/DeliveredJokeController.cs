using Dadabase.Data;
using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadabaseApi.Controllers.v1;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class DeliveredJokeController : ControllerBase
{
    private readonly ILogger<DeliveredJokeController> _logger;
    private IJokeService<DeliveredJoke> _jokeService;

    public DeliveredJokeController(ILogger<DeliveredJokeController> logger, IJokeService<DeliveredJoke> jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }

    [HttpGet()]
    public async Task<IEnumerable<DeliveredJoke>> Get()
    {
        return await _jokeService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<DeliveredJoke> Get(int id)
    {
        return await _jokeService.Get(id);
    }

    [HttpPost()]
    public async Task<DeliveredJoke> Add(DeliveredJoke t)
    {
        await _jokeService.Add(t);
        return t;
    }

    [HttpDelete("{id}")]
    public async Task<DeliveredJoke> Delete(int id)
    {
        return await _jokeService.Delete(id);
    }

    [HttpPut()]
    public async Task<DeliveredJoke> Update(DeliveredJoke t)
    {
        await _jokeService.Update(t);
        return t;
    }
}