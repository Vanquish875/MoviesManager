global using Microsoft.EntityFrameworkCore;
global using MoviesManager.DataManager;
using MoviesManager.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseInMemoryDatabase("moviedb"));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/movies", async (DataContext context) => await context.Movies.ToListAsync());

app.MapPost("/movies", async (DataContext context, Movie movie) =>
{
    context.Movies.Add(movie);
    await context.SaveChangesAsync();
    return Results.Ok(await context.Movies.ToListAsync());
});

app.Run();