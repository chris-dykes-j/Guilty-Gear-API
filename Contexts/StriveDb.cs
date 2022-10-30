using Microsoft.EntityFrameworkCore;
using StriveAPI.Entities;

namespace StriveAPI.Contexts;

public class StriveDb : DbContext
{
    public StriveDb(DbContextOptions<StriveDb> options) : base(options) { }
    public DbSet<Character> Characters { get; set; } = null!;
    public DbSet<Move> Moves { get; set; } = null!;
}