using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StriveDb>(options =>
    options.UseNpgsql("Database=ggstrive;Username=chris"));

var app = builder.Build();

app.UseRouting();
app.UseEndpoints(e => e.MapControllers());

app.Run();