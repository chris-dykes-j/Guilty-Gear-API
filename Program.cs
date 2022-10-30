using Microsoft.EntityFrameworkCore;
using StriveAPI;
using StriveAPI.Contexts;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<StriveDb>(options =>
    options.UseNpgsql("Database=ggstrive;Username=chris"));

var app = builder.Build();



app.Run();