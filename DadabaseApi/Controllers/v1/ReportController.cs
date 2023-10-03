using Microsoft.AspNetCore.Mvc;
using Dadabase.Data;
using Microsoft.EntityFrameworkCore;
using Dadabase.Services;

namespace DadabaseApi.Controllers.v1;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class ReportController : ControllerBase
{
    private readonly ILogger<ReportController> _logger;
    private IReportService<Joke> _reportService;

    public ReportController(ILogger<ReportController> logger, IReportService<Joke> reportService)
    {
        _logger = logger;
        _reportService = reportService;
    }

    [HttpGet("by_tag/{id}")]
    public async Task<IEnumerable<Joke>> GetByTag(int id)
    {
        return await _reportService.GetJokesByTag(id);
    }

    [HttpGet("told_to_audience/{id}")]
    public async Task<IEnumerable<Joke>> GetByAudience(int id)
    {
        return await _reportService.GetJokesToldToAudience(id);
    }

    [HttpGet("ranked/by_score/")]
    public async Task<IEnumerable<Joke>> GetByScore()
    {
        return await _reportService.GetRankedJokesByScore();
    }

    [HttpGet("ranked/by_score/by_tag/{id}")]
    public async Task<IEnumerable<Joke>> GetByScoreForTag(int id)
    {
        return await _reportService.GetRankedJokesByScoreForTag(id);
    }

    [HttpGet("ranked/by_score/for_audience/{id}")]
    public async Task<IEnumerable<Joke>> GetByScoreForAudience(int id)
    {
        return await _reportService.GetRankedJokesByScoreForAudience(id);
    }
}