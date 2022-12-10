using Microsoft.EntityFrameworkCore;
using StriveAPI.Entities;

namespace StriveAPI.Contexts;

public class GuiltyGearDb : DbContext
{
    public GuiltyGearDb(DbContextOptions<GuiltyGearDb> options) : base(options) { }
    public DbSet<StriveCharacter> StriveCharacters { get; set; } = null!;
    public DbSet<StriveMove> StriveMoves { get; set; } = null!;
    public DbSet<XrdCharacter> XrdCharacters { get; set; } = null!;

    public DbSet<XrdMove> XrdMoves { get; set; } = null!;
    public DbSet<AccentCoreCharacter> AccentCoreCharacters { get; set; }
    public DbSet<AccentCoreMove> AccentCoreMoves { get; set; }

}