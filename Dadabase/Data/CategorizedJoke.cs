namespace Dadabase.Data;

public partial class CategorizedJoke
{
    public int Id { get; set; }

    public int? Jokeid { get; set; }

    public int? Jokecategoryid { get; set; }

    public virtual Joke? Joke { get; set; }

    public virtual JokeCategory? Jokecategory { get; set; }
}
