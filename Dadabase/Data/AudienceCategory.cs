namespace Dadabase.Data;

public partial class AudienceCategory
{
    public int Id { get; set; }

    public string? Categoryname { get; set; }

    public string? Description { get; set; }

    public virtual ICollection<CategorizedAudience> Categorizedaudiences { get; set; } = new List<CategorizedAudience>();
}
