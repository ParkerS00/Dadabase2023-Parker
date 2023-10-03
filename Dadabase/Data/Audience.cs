namespace Dadabase.Data;

public partial class Audience
{
    public int Id { get; set; }

    public string? Audiencename { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CategorizedAudience> Categorizedaudiences { get; set; } = new List<CategorizedAudience>();

    public virtual ICollection<DeliveredJoke> Deliveredjokes { get; set; } = new List<DeliveredJoke>();
}
