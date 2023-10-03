namespace Dadabase.Data;

public partial class JokeCategory
{
    public int Id { get; set; }

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CategorizedJoke> Categorizedjokes { get; set; } = new List<CategorizedJoke>();
}
