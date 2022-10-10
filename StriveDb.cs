using Microsoft.EntityFrameworkCore;

namespace StriveAPI;

public class StriveDb : DbContext
{
    public StriveDb(DbContextOptions<StriveDb> options) : base(options) { }
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Move> Moves => Set<Move>();
    
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseNpgsql("Database=ggstrive;Username=chris;");
}

public class Character
{
    public int CharId { get; set; }
    public string? CharName { get; set; }
}

public class Move
{
    public int MoveId { get; set; }
    public int CharId { get; set; }
    public string? MoveName { get; set; }
    public string? Input { get; set; }
    public string? Damage { get; set; }
    public string? Guard { get; set; }
    public string? Startup { get; set; }
    public string? Active { get; set; }
    public string? Recovery { get; set; }
    public string? Block { get; set; }
    public string? Invulnerability { get; set; }
}