namespace Dadabase.Services;

public class JokeService : IJokeService<Joke>
{
    private readonly ILogger<JokeService> _logger;
    private DadabaseContext _context;

    public JokeService(ILogger<JokeService> logger, DadabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<Joke>> GetAll()
    {
        return await _context.Jokes
            .Include(j=>j.CategorizedJokes)
                .ThenInclude(cj=>cj.Jokecategory)
            .Include(j=>j.DeliveredJokes)
                .ThenInclude(dj => dj.Jokereaction)
            .ToListAsync();
    }

    public async Task<Joke> Get(int id)
    {
        _logger.LogInformation("Getting Joke {id}", id);
        return await _context.Jokes
            .Include(j => j.CategorizedJokes)
                .ThenInclude(cj => cj.Jokecategory)
            .Include(j => j.DeliveredJokes)
                .ThenInclude(dj => dj.Jokereaction)
            .FirstOrDefaultAsync(j => j.Id == id);
    }

    public async Task<Joke> Add(Joke joke)
    {
        _logger.LogInformation("Adding Joke {id}", joke.Id);
        _context.Jokes.Add(joke);
        await _context.SaveChangesAsync();
        return joke;
    }

    public async Task<Joke> Delete(int id)
    {
        var joke = _context.Jokes.Single(j => j.Id == id);

        try
        {
            _logger.LogInformation("Trying to Delete Joke {id}", id);
            _context.Jokes.Remove(joke);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Success!");
            return joke;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("You need to delete the parents of this child first.");
        }
    }

    public async Task<Joke> Update(Joke joke)
    {
        _logger.LogInformation("Trying to update Joke {id}", joke.Id);
        _context.Jokes.Update(joke);
        await _context.SaveChangesAsync();
        return joke;
    }
}