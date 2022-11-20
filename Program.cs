using Microsoft.EntityFrameworkCore;
using StriveAPI.Contexts;
using StriveAPI.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options => options.ReturnHttpNotAcceptable = true);

/*
builder.Services.AddCors(options =>
    options.AddPolicy(name: "client", policy => policy.WithOrigins(Environment.GetEnvironmentVariable(""))));
*/

// Add Postgres
builder.Services.AddDbContext<GuiltyGearDb>(options =>
    options.UseNpgsql(Environment.GetEnvironmentVariable("GG_DB")));

// Add the automapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

builder.Services.AddScoped(typeof(StriveCharacterRepository));

var app = builder.Build();

app.UseRouting();
// app.UseCors("client");
app.UseEndpoints(e => e.MapControllers());

app.Run();