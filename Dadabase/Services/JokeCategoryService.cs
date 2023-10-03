namespace Dadabase.Services;

public class JokeCategoryService : IJokeService<JokeCategory>
{
    private readonly ILogger<JokeCategory> _logger;
    private DadabaseContext _context;

    public JokeCategoryService(ILogger<JokeCategory> logger, DadabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<JokeCategory>> GetAll()
    {
        _logger.LogInformation("Getting all Joke Categories");
        return await _context.Jokecategories.ToListAsync();
    }

    public async Task<JokeCategory> Get(int id)
    {
        _logger.LogInformation("Getting Joke Category {id}", id);
        return await _context.Jokecategories.FindAsync(id);
    }

    public async Task<JokeCategory> Add(JokeCategory joke)
    {
        _logger.LogInformation("Adding Joke {id}", joke.Id);
        _context.Jokecategories.Add(joke);
        await _context.SaveChangesAsync();
        return joke;
    }

    public async Task<JokeCategory> Delete(int id)
    {
        var joke = _context.Jokecategories.Single(j => j.Id == id);

        try
        {
            _logger.LogInformation("Trying to delete Joke {id}", id);
            _context.Jokecategories.Remove(joke);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Success!");
            return joke;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("You need to delete the parents of this child first.");
        }
    }

    public async Task<JokeCategory> Update(JokeCategory joke)
    {
        _logger.LogInformation("Updating Joke {id}", joke.Id);
        _context.Jokecategories.Update(joke);
        await _context.SaveChangesAsync();
        return joke;
    }
}