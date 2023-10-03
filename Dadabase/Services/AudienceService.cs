namespace Dadabase.Services;

public class AudienceService : IJokeService<Audience>
{
    private readonly ILogger<AudienceService> _logger;
    private DadabaseContext _context;

    public AudienceService(ILogger<AudienceService> logger, DadabaseContext context)
    {
        _logger = logger;
        _context = context;
    }

    public async Task<IEnumerable<Audience>> GetAll()
    {
        _logger.LogInformation("Getting All Services");
        return await _context.Audiences.ToListAsync();
    }

    public async Task<Audience> Get(int id)
    {
        _logger.LogInformation("Getting Audience {id}", id);
        return await _context.Audiences.FindAsync(id);
    }

    public async Task<Audience> Add(Audience audience)
    {
        _logger.LogInformation("Adding new Audience {id}", audience.Id);
        _context.Audiences.Add(audience);
        await _context.SaveChangesAsync();
        return audience;
    }

    public async Task<Audience> Delete(int id)
    {
        var audience = _context.Audiences.Single(a => a.Id == id);
        try
        {
            _logger.LogInformation("Trying to delete Audience {id}", id);
            _context.Audiences.Remove(audience);
            await _context.SaveChangesAsync();
            _logger.LogInformation("Success!");
            return audience;
        }
        catch (Exception ex)
        {
            throw new InvalidOperationException("You need to delete the parents of this child first.");
        }
    }

    public async Task<Audience> Update(Audience audience)
    {
        _logger.LogInformation("Updating Audience {id}", audience.Id);
        _context.Audiences.Update(audience);
        await _context.SaveChangesAsync();
        return audience;
    }
}