namespace Dadabase.Data;

public partial class CategorizedAudience
{
    public int Id { get; set; }

    public int Audienceid { get; set; }

    public int Audiencecategoryid { get; set; }

    public virtual Audience Audience { get; set; } = null!;

    public virtual AudienceCategory Audiencecategory { get; set; } = null!;
}
