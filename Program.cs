using Microsoft.EntityFrameworkCore;
using StriveAPI;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StriveDb>(options => options.UseInMemoryDatabase("ggstrive"));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();
var app = builder.Build();

app.MapGet("/", async (StriveDb db) =>
{
    await db.Characters.ToListAsync();
});

app.MapGet("/{id}", async (int id, StriveDb db) =>
{
    await (db.Moves.FindAsync(id) is Move move ? Results.Ok(move) : Results.NotFound());
});

app.Run();