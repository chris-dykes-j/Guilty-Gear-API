using Microsoft.EntityFrameworkCore;

namespace StriveAPI.Contexts;

public class StriveDb : DbContext
{
    public StriveDb(DbContextOptions<StriveDb> options) : base(options) { }
}