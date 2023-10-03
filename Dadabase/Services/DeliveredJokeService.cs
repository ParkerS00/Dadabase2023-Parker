namespace Dadabase.Services;

public class DeliveredJokeService : IJokeService<DeliveredJoke>
{
    private readonly ILogger<DeliveredJoke> _logger;
    private DadabaseContext _context;

    public DeliveredJokeService(ILogger<DeliveredJoke> logger, DadabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<DeliveredJoke>> GetAll()
    {
        _logger.LogInformation("Getting All Delivered Jokes");
        return await _context.Deliveredjokes.ToListAsync();
    }

    public async Task<DeliveredJoke> Get(int id)
    {
        _logger.LogInformation("Getting Delivered Joke {id}", id);
        return await _context.Deliveredjokes.FindAsync(id);
    }

    public async Task<DeliveredJoke> Add(DeliveredJoke joke)
    {
        _logger.LogInformation("Adding new Delivered Joke {id}", joke.Id);
        _context.Deliveredjokes.Add(joke);
        await _context.SaveChangesAsync();
        return joke;
    }

    public async Task<DeliveredJoke> Delete(int id)
    {
        _logger.LogInformation("Deleting Delivered Joke {id}", id);
        var joke = _context.Deliveredjokes.Single(j => j.Id == id);
        _context.Deliveredjokes.Remove(joke);
        await _context.SaveChangesAsync();
        return joke;
    }

    public async Task<DeliveredJoke> Update(DeliveredJoke joke)
    {
        _logger.LogInformation("Updating Delivered Joke {id}", joke.Id);
        _context.Deliveredjokes.Update(joke);
        await _context.SaveChangesAsync();
        return joke;
    }
}