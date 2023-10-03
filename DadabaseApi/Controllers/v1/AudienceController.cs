using Microsoft.AspNetCore.Mvc;
using Dadabase.Data;
using Microsoft.EntityFrameworkCore;
using Dadabase.Services;

namespace DadabaseApi.Controllers;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class AudienceController : ControllerBase
{
    private readonly ILogger<AudienceController> _logger;
    private IJokeService<Audience> _audienceService;

    public AudienceController(ILogger<AudienceController> logger, IJokeService<Audience> audienceService)
    {
        _logger = logger;
        _audienceService = audienceService;
    }

    [HttpGet()]
    public async Task<IEnumerable<Audience>> Get()
    {
        return await _audienceService.GetAll();
    }

    [HttpGet("{id}")]
    public async Task<Audience> Get(int id)
    {
        return await _audienceService.Get(id);
    }

    [HttpPost()]
    public async Task<Audience> Add(Audience audience)
    {
        await _audienceService.Add(audience);
        return audience;
    }

    [HttpDelete("{id}")]
    public async Task<Audience> Delete(int id)
    {
        return await _audienceService.Delete(id);
    }

    [HttpPut()]
    public async Task<Audience> Update(Audience audience)
    {
        await _audienceService.Update(audience);
        return audience;
    }
}