namespace Dadabase.Data;

public partial class JokeReactionCategory
{
    public int Id { get; set; }

    public string? Reactionlevel { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<DeliveredJoke> Deliveredjokes { get; set; } = new List<DeliveredJoke>();
}
