using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

// Add Postgres
builder.Services.AddDbContext<StriveDb>(options =>
        options.UseNpgsql("Server=localhost;Database=ggstrive;Port=5432;Username=chris"));

// Add the automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(CharacterRepository));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();