using Microsoft.EntityFrameworkCore;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options)
        : base(options)
    { }
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Stroj>()
            .Property(s => s.Kategorija)
            .HasConversion<string>()
            .HasColumnType("text");
    }

    public DbSet<Stroj> Strojevi { get; set; }
    public DbSet<Kvar> Kvarovi { get; set; }
}