using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

// Add Postgres
builder.Services.AddDbContext<GuiltyGearDb>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("GG_DB")));

// Add the automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(StriveRepository));
builder.Services.AddScoped(typeof(XrdRepository));
builder.Services.AddScoped(typeof(AccentCoreRepository));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();