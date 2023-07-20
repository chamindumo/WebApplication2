using Microsoft.EntityFrameworkCore;
using WebApplication2.Data;
using WebApplication2.Models;
using Serilog;
using WebApplication2;
using WebApplication2.Middelware;
using WebApplication2.Repositery;
using WebApplication2.Service;
using WebApplication2.DTO;

var builder = WebApplication.CreateBuilder(args);
var logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .Enrich.FromLogContext()
    .CreateLogger();
builder.Logging.ClearProviders();
builder.Logging.AddSerilog(logger);
//builder.Services.AddTransient<BasicAuthHandler>();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<DataContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddTransient<IBookService, BookRepository>(); 
builder.Services.AddTransient< BookRepository>();

//builder.Services.AddTransient<GlobaleExceptionHandlingMiddelware>();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<BasicAuthHandler>("Test");
//app.UseMiddleware<GlobaleExceptionHandlingMiddelware>();

app.UseHttpsRedirection();


app.MapGet("/Books", async (HttpContext httpContext) =>
{
    var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
    var books = await repository.GetAllBooksAsync();
    return Results.Ok(books);
});

app.MapGet("/Books/{id}", async (HttpContext httpContext, int id) =>
{
    var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
    var book = await repository.GetBookByIdAsync(id);
    return book is not null ? Results.Ok(book) : Results.NotFound("Book Not Found");
});

app.MapPost("Add/Book", async (HttpContext httpContext, BookInputDTO inputDTO) =>
{
    var repository = httpContext.RequestServices.GetRequiredService<IBookService>();

    var book = new Books
    {
        Title = inputDTO.Title,
        Author = inputDTO.Author
    };

    await repository.AddBookAsync(book);

    // Map the created book to the BookOutputDTO and return it
    var outputDTO = new BookOutputDTO
    {
        Id = book.Id,
        Title = book.Title,
        Author = book.Author
    };

    return Results.Ok(outputDTO);
});

app.MapPut("/Book/{id}", async (HttpContext httpContext, BookInputDTO inputDTO, int id) =>
{
    var repository = httpContext.RequestServices.GetRequiredService<IBookService>();

    var existingBook = await repository.GetBookByIdAsync(id);
    if (existingBook == null)
    {
        return Results.NotFound("Book not found");
    }

    existingBook.Title = inputDTO.Title;
    existingBook.Author = inputDTO.Author;

    await repository.UpdateBookAsync(id, existingBook);

    // Map the updated book to the BookOutputDTO and return it
    var outputDTO = new BookOutputDTO
    {
        Id = existingBook.Id,
        Title = existingBook.Title,
        Author = existingBook.Author
    };

    return Results.Ok(outputDTO);
});

app.MapDelete("/Book/{id}", async (HttpContext httpContext, int id) =>
{
    var repository = httpContext.RequestServices.GetRequiredService<BookRepository>();
    await repository.DeleteBookAsync(id);
    return Results.Ok(await repository.GetAllBooksAsync());
});

app.Run();
