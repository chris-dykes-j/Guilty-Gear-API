using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

// Add Postgres
builder.Services.AddDbContext<StriveDb>(options =>
    options.UseNpgsql("Database=ggstrive;Username=chris"));

// Add the automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();