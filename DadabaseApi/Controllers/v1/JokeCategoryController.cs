using Dadabase.Data;
using Dadabase.Services;
using Microsoft.AspNetCore.Mvc;

namespace DadabaseApi.Controllers.v1;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class JokeCategoryController : ControllerBase
{
    private readonly ILogger<JokeCategoryController> _logger;
    private IJokeService<JokeCategory> _jokeService;

    public JokeCategoryController(ILogger<JokeCategoryController> logger, IJokeService<JokeCategory> jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }

    [HttpGet()]
    public async Task<IEnumerable<JokeCategory>> Get()
    {
        return await _jokeService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<JokeCategory> Get(int id)
    {
        return await _jokeService.Get(id);
    }

    [HttpPost()]
    public async Task<JokeCategory> Add(JokeCategory tag)
    {
        await _jokeService.Add(tag);
        return tag;
    }

    [HttpDelete("{id}")]
    public async Task<JokeCategory> Delete(int id)
    {
        return await _jokeService.Delete(id);
    }

    [HttpPut()]
    public async Task<JokeCategory> Update(JokeCategory tag)
    {
        await _jokeService.Update(tag);
        return tag;
    }
}