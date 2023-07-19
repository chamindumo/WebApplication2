
using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using Serilog;


var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapGet("/books", async (DataContext context) => await context.Books.ToListAsync());

app.MapGet("/books/{id}", async (DataContext context, int id) => await context.Books.FindAsync(id) is Books item ? Results.Ok(item) : Results.NotFound("Book Not Found"));


async Task<List<Books>> GetBooks(DataContext context) => await context.Books.ToListAsync();
app.MapPost("Add/Book", async (DataContext context, Books item) =>
{
    context.Books.Add(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetBooks(context));
});

//
app.MapPut("/Book/{id}", async (DataContext context, Books item, int id) =>
{
    var bookitem = await context.Books.FindAsync(id);
    if (bookitem == null) return Results.NotFound("book is not FOu");
    bookitem.Title = item.Title;
    bookitem.Author = item.Author;
    context.Books.Update(item);
    await context.SaveChangesAsync();
    return Results.Ok(await GetBooks(context));
});


app.MapDelete("/Book/{id}", async (DataContext context, int id) =>
{
    var bookitem = await context.Books.FindAsync(id);
    if (bookitem == null) return Results.NotFound("book is not found");
    context.Remove(bookitem);
    await context.SaveChangesAsync();
    return Results.Ok(await GetBooks(context));
});


app.Run();

