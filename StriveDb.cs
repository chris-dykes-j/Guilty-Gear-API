using Microsoft.EntityFrameworkCore;

namespace StriveAPI;

public class StriveDb : DbContext
{
    public StriveDb(DbContextOptions<StriveDb> options) : base(options) { }
    public DbSet<Character> Characters => Set<Character>();
    public DbSet<Move> Moves => Set<Move>();
}

public class Character
{
    public int Id { get; set; }
    public string? Name { get; set; }
}

public class Move
{
    public int Id { get; set; }
    public string? Name { get; set; }
}