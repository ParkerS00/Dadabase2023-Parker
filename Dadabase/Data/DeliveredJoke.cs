namespace Dadabase.Data;

public partial class DeliveredJoke
{
    public int Id { get; set; }

    public DateOnly? Delivereddate { get; set; }

    public int? Jokereactionid { get; set; }

    public int? Jokeid { get; set; }

    public int? Audienceid { get; set; }

    public string? Notes { get; set; }

    public virtual Audience? Audience { get; set; }

    public virtual Joke? Joke { get; set; }

    public virtual JokeReactionCategory? Jokereaction { get; set; }
}
