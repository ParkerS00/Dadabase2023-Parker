namespace DadabaseApi.Controllers.v1;

[Route("v{version:apiVersion}/[controller]")]
[ApiController]
[ApiVersion("1.0")]
public class JokeController : ControllerBase
{
    private readonly ILogger<JokeController> _logger;
    private IJokeService<Joke> _jokeService;

    public JokeController(ILogger<JokeController> logger, IJokeService<Joke> jokeService)
    {
        _logger = logger;
        _jokeService = jokeService;
    }

    [HttpGet()]
    public async Task<IEnumerable<JokeDTO>> Get()
    {
        var jokes = await _jokeService.GetAll();
        return jokes.Select(j => MakeJokeDTO(j));
    }

    [HttpGet("{id}")]
    public async Task<JokeDTO> Get(int id)
    {
        var jokes = await _jokeService.Get(id);
        return MakeJokeDTO(jokes);
    }

    [HttpPost()]
    public async Task<JokeDTO> Add(JokeRequest request)
    {
        Joke joke = new Joke
        {
            JokeName = request.name,
            JokeText = request.jokeText,
            Id = request.id
        };
        await _jokeService.Add(joke);
        return MakeJokeDTO(joke);
    }

    [HttpDelete("{id}")]
    public async Task<Joke> Delete(int id)
    {
        return await _jokeService.Delete(id);
    }

    [HttpPut()]
    public async Task<JokeDTO> Update(Joke joke)
    {
        await _jokeService.Update(joke);
        return MakeJokeDTO(joke);
    }

    private JokeDTO MakeJokeDTO(Joke j)
    {
        return new JokeDTO
        {
            name = j.JokeName,
            jokeText = j.JokeText,
            lastDateDelivered = j.DeliveredJokes.Count == 0 ? "No Joke Found" :
                j.DeliveredJokes.OrderByDescending(d => d.Delivereddate).First().Delivereddate.ToString(),
            categories = string.Join(", ", j.CategorizedJokes.Select(c => c.Jokecategory).Select(cj => cj.Categoryname))
        };
    }
}





