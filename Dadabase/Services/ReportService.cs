namespace Dadabase.Services;

public class ReportService : IReportService<Joke>
{
    private readonly ILogger<JokeService> _logger;
    private DadabaseContext _context;

    public ReportService(ILogger<JokeService> logger, DadabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<Joke>> GetJokesByTag(int categoryId)
    {
        _logger.LogInformation("Getting Jokes by Category {id}", categoryId);
        var results = await _context.Jokes
            .Include(j => j.DeliveredJokes)
            .Include(j => j.CategorizedJokes)
            .Where(j => j.CategorizedJokes
                .Any(c => c.Jokecategoryid == categoryId))
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<Joke>> GetJokesToldToAudience(int audienceId)
    {
        _logger.LogInformation("Getting Jokes told to Audience {id}", audienceId);
        var results = await _context.Jokes
            .Include(j => j.DeliveredJokes)
            .Where(j => j.DeliveredJokes
                .Any(c => c.Audienceid == audienceId))
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<Joke>> GetRankedJokesByScore()
    {
        _logger.LogInformation("Getting Ranked Jokes by Score");
        var results = await _context.Jokes
            .Include(j => j.DeliveredJokes)
            .OrderByDescending(j => j.DeliveredJokes
                .Sum(d => d.Jokereactionid))
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<Joke>> GetRankedJokesByScoreForTag(int categoryId)
    {
        _logger.LogInformation("Getting Ranked Jokes by Score For Category {id}", categoryId);
        var results = await _context.Jokes
            .Include(j => j.DeliveredJokes)
            .Include(j => j.CategorizedJokes)
            .Where(j => j.CategorizedJokes
                .Any(c => c.Jokecategoryid == categoryId))
            .OrderByDescending(j => j.DeliveredJokes
                .Sum(d => d.Jokereactionid))
            .ToListAsync();

        return results;
    }

    public async Task<IEnumerable<Joke>> GetRankedJokesByScoreForAudience(int audienceId)
    {
        _logger.LogInformation("Getting Ranked Jokes by Score for Audience {id}", audienceId);
        var results = await _context.Jokes
            .Include(j => j.DeliveredJokes)
            .Where(j => j.DeliveredJokes
                .Any(c => c.Audienceid == audienceId))
            .OrderByDescending(j => j.DeliveredJokes
                .Sum(d => d.Jokereactionid))
            .ToListAsync();

        return results;
    }
}
