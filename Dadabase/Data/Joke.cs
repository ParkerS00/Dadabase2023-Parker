namespace Dadabase.Data;

public partial class Joke
{
    public int Id { get; set; }

    public string? JokeName { get; set; }

    public string? JokeText { get; set; }

    public virtual ICollection<CategorizedJoke> CategorizedJokes { get; set; } = new List<CategorizedJoke>();

    public virtual ICollection<DeliveredJoke> DeliveredJokes { get; set; } = new List<DeliveredJoke>();
}

