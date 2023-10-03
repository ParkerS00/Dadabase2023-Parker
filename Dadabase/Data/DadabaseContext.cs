namespace Dadabase.Data;

public partial class DadabaseContext : DbContext
{
    public DadabaseContext()
    {
    }

    public DadabaseContext(DbContextOptions<DadabaseContext> options)
        : base(options)
    {
    }

    public virtual DbSet<Audience> Audiences { get; set; }

    public virtual DbSet<AudienceCategory> Audiencecategories { get; set; }

    public virtual DbSet<CategorizedAudience> Categorizedaudiences { get; set; }

    public virtual DbSet<CategorizedJoke> Categorizedjokes { get; set; }

    public virtual DbSet<DeliveredJoke> Deliveredjokes { get; set; }

    public virtual DbSet<Joke> Jokes { get; set; }

    public virtual DbSet<JokeCategory> Jokecategories { get; set; }

    public virtual DbSet<JokeReactionCategory> Jokereactioncategories { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Audience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audience_pkey");

            entity.ToTable("audience", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Audiencename)
                .HasColumnType("character varying")
                .HasColumnName("audiencename");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
        });

        modelBuilder.Entity<AudienceCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("audiencecategory_pkey");

            entity.ToTable("audiencecategory", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasColumnType("character varying")
                .HasColumnName("categoryname");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
        });

        modelBuilder.Entity<CategorizedAudience>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedaudience_pkey");

            entity.ToTable("categorizedaudience", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Audiencecategoryid).HasColumnName("audiencecategoryid");
            entity.Property(e => e.Audienceid).HasColumnName("audienceid");

            entity.HasOne(d => d.Audiencecategory).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audiencecategoryid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audiencecategoryid_fkey");

            entity.HasOne(d => d.Audience).WithMany(p => p.Categorizedaudiences)
                .HasForeignKey(d => d.Audienceid)
                .OnDelete(DeleteBehavior.ClientSetNull)
                .HasConstraintName("categorizedaudience_audienceid_fkey");
        });

        modelBuilder.Entity<CategorizedJoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("categorizedjoke_pkey");

            entity.ToTable("categorizedjoke", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Jokecategoryid).HasColumnName("jokecategoryid");
            entity.Property(e => e.Jokeid).HasColumnName("jokeid");

            entity.HasOne(d => d.Jokecategory).WithMany(p => p.Categorizedjokes)
                .HasForeignKey(d => d.Jokecategoryid)
                .HasConstraintName("categorizedjoke_jokecategoryid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.CategorizedJokes)
                .HasForeignKey(d => d.Jokeid)
                .HasConstraintName("categorizedjoke_jokeid_fkey");
        });

        modelBuilder.Entity<DeliveredJoke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("deliveredjoke_pkey");

            entity.ToTable("deliveredjoke", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Audienceid).HasColumnName("audienceid");
            entity.Property(e => e.Delivereddate)
                .HasDefaultValueSql("CURRENT_DATE")
                .HasColumnName("delivereddate");
            entity.Property(e => e.Jokeid).HasColumnName("jokeid");
            entity.Property(e => e.Jokereactionid).HasColumnName("jokereactionid");
            entity.Property(e => e.Notes)
                .HasMaxLength(64)
                .HasColumnName("notes");

            entity.HasOne(d => d.Audience).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Audienceid)
                .HasConstraintName("deliveredjoke_audienceid_fkey");

            entity.HasOne(d => d.Joke).WithMany(p => p.DeliveredJokes)
                .HasForeignKey(d => d.Jokeid)
                .HasConstraintName("deliveredjoke_jokeid_fkey");

            entity.HasOne(d => d.Jokereaction).WithMany(p => p.Deliveredjokes)
                .HasForeignKey(d => d.Jokereactionid)
                .HasConstraintName("deliveredjoke_jokereactionid_fkey");
        });

        modelBuilder.Entity<Joke>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("joke_pkey");

            entity.ToTable("joke", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.JokeName)
                .HasColumnType("character varying")
                .HasColumnName("jokename");
            entity.Property(e => e.JokeText)
                .HasMaxLength(128)
                .HasColumnName("joketext");
        });

        modelBuilder.Entity<JokeCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokecategory_pkey");

            entity.ToTable("jokecategory", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Categoryname)
                .HasColumnType("character varying")
                .HasColumnName("categoryname");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
        });

        modelBuilder.Entity<JokeReactionCategory>(entity =>
        {
            entity.HasKey(e => e.Id).HasName("jokereactioncategory_pkey");

            entity.ToTable("jokereactioncategory", "dadabase_f23");

            entity.Property(e => e.Id)
                .ValueGeneratedNever()
                .HasColumnName("id");
            entity.Property(e => e.Description)
                .HasMaxLength(64)
                .HasColumnName("description");
            entity.Property(e => e.Reactionlevel)
                .HasMaxLength(16)
                .HasColumnName("reactionlevel");
        });

        OnModelCreatingPartial(modelBuilder);
    }

    partial void OnModelCreatingPartial(ModelBuilder modelBuilder);
}
